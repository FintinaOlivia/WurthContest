namespace SoftwarePirates
{
    public interface IShipEditModel
    {
        string Name { get; set; }
        string Modifiers { get; set; }
        string ShipType { get; set; }
        int Cannons { get; set; }
        int Crew { get; set; }
        int MinCrew { get; }
        int MaxCrew { get; }
        int MaxCannons { get; }
        bool DisplayAddToFleet();
        bool DisplayDependentOptions();
    }
}
