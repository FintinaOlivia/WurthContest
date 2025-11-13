namespace SoftwarePirates.Models
{
    public class ShipEditModel : IShipEditModel
    {
        private IShipTypeService _shipTypeService;

        public ShipEditModel(IShipTypeService shipTypeService) => _shipTypeService = shipTypeService;

        public string Name { get; set; } = string.Empty;
        public string Modifiers { get; set; } = string.Empty;
        public string ShipType { get; set; } = string.Empty;
        public int Cannons { get; set; }
        public int Crew { get; set; }

        public int MinCrew => _shipTypeService.GetCards().FirstOrDefault(s => s.TypeName == ShipType)?.MinCrew ?? 0;

        public int MaxCrew => _shipTypeService.GetCards().FirstOrDefault(s => s.TypeName == ShipType)?.MaxCrew ?? 0;

        public int MaxCannons => _shipTypeService.GetCards().FirstOrDefault(s => s.TypeName == ShipType)?.MaxCannons ?? 0;

        public bool DisplayAddToFleet()
        {
            return DisplayDependentOptions() && !string.IsNullOrWhiteSpace(Name);
        }

        public bool DisplayDependentOptions()
        {
            return !string.IsNullOrWhiteSpace(ShipType);
        }
    }
}
