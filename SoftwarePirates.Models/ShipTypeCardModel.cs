namespace SoftwarePirates.Models
{
    public class ShipTypeCardModel : IShipTypeCardModel
    {
        public string ApIcon { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string PhysicalSize { get; set; } = string.Empty;
        public string Manueverability { get; set; } = string.Empty;
        public string Durability { get; set; } = string.Empty;
        public string ComparativeSpeed { get; set; } = string.Empty;
        public string[]? Notes { get; set; }
        public int MaxCannons { get; set; }
        public int MaxCrew { get; set; }
        public int MinCrew { get; set; }
        public int IdealCrew { get; set; }
        public int CargoCapacity { get; set; }
        public int SalePrice { get; set; }

        public bool HasNotes() => Notes is not null && Notes.Length > 0;
    }
}
