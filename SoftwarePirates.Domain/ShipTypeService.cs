using SoftwarePirates.Models;

namespace SoftwarePirates.Domain
{
    public class ShipTypeService : IShipTypeService
    {
        private readonly List<Ship> _shipTypes = new List<Ship>()
        {
            new Ship
            {
                ApIcon = "8",
                ShipType = ShipTypes.Pinnace.GetDescription(),
                PhysicalSizes = PhysicalSizes.VerySmall,
                Manueverabilities = Maneuverabilities.VeryHigh,
                Durability = Durabilities.VeryLow.GetDescription(),
                ComparativeSpeeds = ComparativeSpeeds.VeryHigh,
                MaxCannons = 10,
                MaxCrew = 60,
                MinCrew = 6,
                IdealCrew = 36,
                CargoCapacity = 25,
                SalePrice = 225,
                TypeName = "Pinnace"
            },
            new Ship
            {
                ApIcon = "Z",
                ShipType = ShipTypes.Sloop.GetDescription(),
                PhysicalSizes = PhysicalSizes.Small,
                Manueverabilities = Maneuverabilities.High,
                Durability = "Low",
                ComparativeSpeeds = ComparativeSpeeds.High,
                MaxCannons = 12,
                MaxCrew = 75,
                MinCrew = 8,
                IdealCrew = 44,
                CargoCapacity = 40,
                SalePrice = 300,
                TypeName = "Sloop"
            },
            new Ship
            {
                ApIcon = "P",
                ShipType = ShipTypes.WarGalleon.GetDescription(),
                PhysicalSizes = PhysicalSizes.Large,
                Manueverabilities = Maneuverabilities.Low,
                Durability = "High",
                ComparativeSpeeds = ComparativeSpeeds.SlowHigh,
                Notes = ["The default cannon damage is High"],
                MaxCannons = 32,
                MaxCrew = 200,
                MinCrew = 13,
                IdealCrew = 107,
                CargoCapacity = 90,
                SalePrice = 500,
                TypeName = "War Galleon"
            }

        };


        public IEnumerable<IShipTypeCardModel> GetCards()
        {
            return _shipTypes;
        }

        public IEnumerable<IDictionary<string, string>> GetShipTypeData()
        {
            return _shipTypes
                .Select(s => new Dictionary<string, string>
                {
                    { "ApIcon", s.ApIcon },
                    { "Ship Type", s.ShipType },
                    { "Physical Size", s.PhysicalSize.ToString() },
                    { "Manueverability", s.Manueverability },
                    { "Durability", s.Durability },
                    { "Comparative Speed", s.ComparativeSpeed },
                    { "Max Cannons", s.Cannons.ToString() },
                    { "Max Crew", s.MaxCrew.ToString() },
                    { "Min Crew", s.MinCrew.ToString() },
                    { "Ideal Crew", s.IdealCrew.ToString() },
                    { "Cargo Capacity", s.CargoCapacity.ToString() },   
                    { "Sale Price", s.SalePrice.ToString() },
                    { "Cannon Accuracy", s.CannonAccuracy.ToString() },
                })
                .ToList();
        }

        public IEnumerable<string> GetShipTypeSelectOptions()
        {
            return _shipTypes.Select(sd => sd.ShipType);
        }
    }
}
