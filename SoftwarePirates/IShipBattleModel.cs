namespace SoftwarePirates
{
    public interface IShipBattleModel
    {
        string ApIcon { get; }
        string Name { get; }
        int Cost { get; }
        string ShipType { get; }
        string Modifiers { get; }
        int Cannons { get; }
        string CannonAccuracy { get; }
        string CannonDamage { get; }
        string PirateDamage { get; }
        string Manueverability { get; }
        string ComparativeSpeed { get; }
        int Crew { get; }
        int MinCrew { get; }
        int IdealCrew { get; }
        int InoperableCrew { get; }
        int CrippledCrew { get; }
        int FunctionalCrew { get; }
        string Durability { get; }
        int DurabilityCounter { get; }
    }
}
