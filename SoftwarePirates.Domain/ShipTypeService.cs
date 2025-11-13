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
                ShipType = "Pinnace",
                PhysicalSizes = PhysicalSizes.VerySmall,
                Manueverability = "Very High",
                Durability = "Very Low",
                ComparativeSpeed = "Very High",
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
                ShipType = "Sloop",
                PhysicalSizes = PhysicalSizes.Small,
                Manueverability = "High",
                Durability = "Low",
                ComparativeSpeed = "High",
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
                ShipType = "War Galleon",
                PhysicalSizes = PhysicalSizes.Large,
                Manueverability = "Low",
                Durability = "High",
                ComparativeSpeed = "Slow High", 
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
