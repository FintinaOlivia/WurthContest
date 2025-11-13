using SoftwarePirates.Domain.Modifiers;
using SoftwarePirates.Models;
using SoftwarePirates.Transfer;
using System.Collections.Immutable;

namespace SoftwarePirates.Domain
{
    public class FleetBuilderEngine : IFleetBuilderEngine
    {
        #region services
        private readonly IAlertEngine _alertEngine;
        private readonly ShipTypeService shipTypeService = new();
        private readonly ITransferService transferService = new TransferService();
        #endregion

        #region fields
        private static ImmutableList<string> Durabilities =>
        [
            "Very Low",
            "Low",
            "Medium",
            "High",
            "Very High",
            "Very High Plus"
        ];
        private List<Ship> fleetShips { get; set; } = [];
        #endregion

        #region cTor
        public FleetBuilderEngine(IAlertEngine alertEngine)
        {
            _alertEngine = alertEngine;
        }
        #endregion

        #region properties
        public int FleetBudget => 10000;
        public int FleetExpense => fleetShips.Sum(s => CalculateShipCost(s));
        public string FleetName { get; set; } = string.Empty;
        public string ImportText { get; set; } = string.Empty;

        private ShipEditModel? shipEdit;
        public IShipEditModel ShipEdit { get { return shipEdit is null ? (shipEdit = new ShipEditModel(shipTypeService)) : shipEdit; } }
        public string ExportText => transferService.GenerateExportText(FleetName, FleetDisplayModels);
        public IEnumerable<IShipBattleModel> FleetBattleModels => fleetShips;
        public IEnumerable<IShipDisplayModel> FleetDisplayModels => fleetShips;
        public int RemainingBudget => FleetBudget - FleetExpense;
        public IEnumerable<string> ShipTypeOptions => shipTypeService.GetShipTypeSelectOptions();
        #endregion

        #region public methods
        public void AddShipToFleet()
        {
            Ship ship = BuildShip(ShipEdit.Name, ShipEdit.Modifiers, ShipEdit.ShipType, ShipEdit.Cannons, ShipEdit.Crew);

            fleetShips.Add(ship);
            
            shipEdit = null;
        }
        public void ImportFleet()
        {
            _alertEngine.ClearMessages();

            if (!string.IsNullOrWhiteSpace(ImportText))
            {
                var result = transferService.GetImportResult(ImportText);

                FleetName = result.FleetName;
                fleetShips = [];

                var shipNames = new List<string>();

                if (result.ShipLines.Count > 0)
                {
                    for (int n = 0; n < result.ShipLines.Count; n++)
                    {
                        var shipLine = result.ShipLines[n];

                        if (shipNames.Contains(shipLine.Name))
                        {
                            _alertEngine.AddDangerMessage($"Duplicate ship name specified: {shipLine.Name}");
                        }
                        else
                        {
                            shipNames.Add(shipLine.Name);

                            Ship ship = BuildShip(shipLine.Name, shipLine.Modifiers, shipLine.ShipType, shipLine.Cannons, shipLine.Crew);

                            fleetShips.Add(ship);
                        }
                    }

                    foreach (var error in result.LineErrors)
                    {
                        _alertEngine.AddDangerMessage(error);
                    }
                }
            }
        }
        public bool IsOverBudget() => RemainingBudget < 0;
        #endregion

        #region private methods
        private Ship BuildShip(string name, string modifiers, string shipType, int cannons, int crew)
        {
            var shipTypeData = shipTypeService.GetShipTypeData().Where(s => s["Ship Type"] == shipType).First();

            int baseCost = int.TryParse(shipTypeData["Sale Price"], out int i) ? i : 0;
            int minCrew = int.TryParse(shipTypeData["Min Crew"], out int b) ? b : 1;
            int idealCrew = int.TryParse(shipTypeData["Ideal Crew"], out int c) ? c : 1;
            int inoperable = Math.Min(crew, minCrew - 1);
            int crippled = Math.Max(Math.Min(crew - inoperable, idealCrew - minCrew), 0);
            int functional = Math.Max(crew - crippled - inoperable, 0);
            int durability = 0;

            var modifierList = ParseModifiersForShip(modifiers);

            PirateDamages pirateDamages;
            CannonDamages cannonDamages;
            ModiferBasedFields(shipTypeData, out durability, modifierList, out pirateDamages, out cannonDamages);

            Ship ship = new()
            {
                ApIcon = shipTypeData["ApIcon"],
                CannonAccuracies = CannonAccuracies.Medium,
                CannonDamages = cannonDamages,
                Cannons = cannons,
                ComparativeSpeeds = Enum.TryParse<ComparativeSpeeds>(
                    shipTypeData["Comparative Speed"].Replace(" ", ""), true, out var speed) ? speed : ComparativeSpeeds.Medium,
                Cost = baseCost,
                Crew = crew,
                CrippledCrew = crippled,
                Durability = Durabilities[durability],
                DurabilityCounter = (durability + 1) * Constants.DURABILITYCOUNTERS,
                FunctionalCrew = functional,
                IdealCrew = idealCrew,
                InoperableCrew = inoperable,
                Manueverabilities = Enum.TryParse<Maneuverabilities>(
                    shipTypeData["Manueverability"].Replace(" ", ""), true, out var man) ? man : Maneuverabilities.Medium,
                MinCrew = minCrew,
                Modifiers = modifiers,
                Name = name,
                PirateDamages = pirateDamages,
                SalePrice = baseCost,
                ShipType = shipTypeData["Ship Type"],
                ModifierList = modifierList,
            };

            ship.Cost = CalculateShipCost(ship);

            return ship;
        }

        private static void ModiferBasedFields(IDictionary<string, string> shipTypeData, out int durability, (bool Reinforced, bool BigGuns, bool Elite) modifierList, out PirateDamages pirateDamages, out CannonDamages cannonDamages)
        {
            if (modifierList.Reinforced)
            {
                durability = Durabilities.IndexOf(shipTypeData["Durability"]) + 1;
            }
            else
            {
                durability = Durabilities.IndexOf(shipTypeData["Durability"]);
            }

            pirateDamages = modifierList.Elite ? PirateDamages.High : PirateDamages.Medium;
            cannonDamages = CannonDamages.Medium;
            if (modifierList.BigGuns || shipTypeData["Ship Type"] == ShipTypes.WarGalleon.GetDescription())
            {
                cannonDamages = CannonDamages.High;
            }
        }

        private (bool Reinforced, bool BigGuns, bool Elite) ParseModifiersForShip(string modifiers)
        {
            var modifiersTuple = (false, false, false);
            if (modifiers.Contains("Reinforced"))
            {
                modifiersTuple.Item1 = true;
            }
            if(modifiers.Contains("Big guns"))
            {
                modifiersTuple.Item2 = true;
            }
            if (modifiers.Contains("Elite"))
            {
                modifiersTuple.Item3 = true;
            }

            return modifiersTuple;
        }

        private static int CalculateShipCost(Ship ship)
        {
            int baseCost = ship.SalePrice;
            int cannons = ship.Cannons;
            int crew = ship.Crew;

            string modifiers = ship.Modifiers;

            var costBuilder = new ShipCostBuilder(baseCost, cannons, crew);

            if (ship.ModifierList.Reinforced)
            {
                costBuilder.WithReinforced();
            }

            if (ship.ModifierList.BigGuns)
            {
                costBuilder.WithBigGuns();
            }

            if (ship.ModifierList.Elite)
            {
               costBuilder.WithEliteCrew();
            }

            return costBuilder.GetCost();
        }
        #endregion

    }
}
