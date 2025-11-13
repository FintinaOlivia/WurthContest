namespace SoftwarePirates
{
    public interface IShipDisplayModel
    {
        string Name { get; }
        string ShipType { get; }
        int Cannons { get; }
        int Crew { get; }
        string Modifiers { get; }
        int Cost { get; }
    }
}
