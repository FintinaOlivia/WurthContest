namespace SoftwarePirates.Transfer
{
    public record class ShipLine
    {
        public string Name { get; init; } = string.Empty;
        public string Modifiers { get; init; } = string.Empty;
        public string ShipType { get; init; } = string.Empty;
        public int Cannons { get; init; }
        public int Crew { get; init; }
    }
}
