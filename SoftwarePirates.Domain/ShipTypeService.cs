using SoftwarePirates.Models;

namespace SoftwarePirates.Domain
{
    public class ShipTypeService : IShipTypeService
    {
        private readonly List<Dictionary<string, string>> _shipTypes =
        [
            new Dictionary<string, string>
            {
                { "ApIcon", "8" },
                { "Ship Type", "Pinnace" },
                { "Physical Size", "Very Small" },
                { "Manueverability", "Very High" },
                { "Durability", "Very Low" },
                { "Comparative Speed", "Very High" },
                { "Max Cannons", "10" },
                { "Max Crew", "60" },
                { "Min Crew", "6" },
                { "Ideal Crew", "36" },
                { "Cargo Capacity", "25" },
                { "Sale Price", "225" }
            },
            new Dictionary<string, string>
            {
                { "ApIcon", "Z" },
                { "Ship Type", "Sloop" },
                { "Physical Size", "Small" },
                { "Manueverability", "High" },
                { "Durability", "Low" },
                { "Comparative Speed", "High" },
                { "Max Cannons", "12" },
                { "Max Crew", "75" },
                { "Min Crew", "8" },
                { "Ideal Crew", "44" },
                { "Cargo Capacity", "40" },
                { "Sale Price", "300" }
            },
            new Dictionary<string, string>
            {
                { "ApIcon", "P" },
                { "Ship Type", "War Galleon" },
                { "Physical Size", "Large" },
                { "Manueverability", "Low" },
                { "Durability", "High" },
                { "Comparative Speed", "Slow High" },
                { "Notes", "The default cannon damage is High" },
                { "Max Cannons", "32" },
                { "Max Crew", "200" },
                { "Min Crew", "13" },
                { "Ideal Crew", "107" },
                { "Cargo Capacity", "90" },
                { "Sale Price", "500" }
            },
        ];

        public IEnumerable<IShipTypeCardModel> GetCards()
        {
            return _shipTypes.Select(s => new ShipTypeCardModel
            {
                ApIcon = s["ApIcon"],
                TypeName = s["Ship Type"],
                PhysicalSize = s["Physical Size"],
                Manueverability = s["Manueverability"],
                Durability = s["Durability"],
                ComparativeSpeed = s["Comparative Speed"],
                Notes = s.TryGetValue("Notes", out string? notes) ? [notes] : null,
                MaxCannons = int.TryParse(s["Max Cannons"], out int a) ? a : 0,
                MaxCrew = int.TryParse(s["Max Crew"], out int b) ? b : 0,
                MinCrew = int.TryParse(s["Min Crew"], out int c) ? c : 0,
                IdealCrew = int.TryParse(s["Ideal Crew"], out int d) ? d : 0,
                CargoCapacity = int.TryParse(s["Cargo Capacity"], out int e) ? e : 0,
                SalePrice = int.TryParse(s["Sale Price"], out int f) ? f : 0,
            });
        }

        public IEnumerable<IDictionary<string, string>> GetShipTypeData()
        {
            return _shipTypes;
        }

        public IEnumerable<string> GetShipTypeSelectOptions()
        {
            return _shipTypes.Select(sd => sd["Ship Type"]);
        }
    }
}
