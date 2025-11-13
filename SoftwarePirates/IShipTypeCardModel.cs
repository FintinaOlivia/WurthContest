namespace SoftwarePirates
{
    public interface IShipTypeCardModel
    {
        string ApIcon { get; }
        string TypeName { get; }
        string PhysicalSize { get; }
        string Manueverability { get; }
        string Durability { get; }
        string ComparativeSpeed { get; }
        string[]? Notes { get; }
        int MaxCannons { get; }
        int MaxCrew { get; }
        int MinCrew { get; }
        int IdealCrew { get; }
        int CargoCapacity { get; }
        int SalePrice { get; }

        bool HasNotes();
    }
}
