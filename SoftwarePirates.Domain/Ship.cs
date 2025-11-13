namespace SoftwarePirates.Domain
{
    public class Ship : IShipBattleModel, IShipDisplayModel, IShipTypeCardModel
    {
        public string ApIcon { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Cost { get; set; }

        public string ShipType { get; set; } = string.Empty;

        public string PhysicalSize { get; set; } = string.Empty;

        public string Modifiers { get; set; } = string.Empty;

        public int Cannons { get; set; }

        public string CannonAccuracy { get; set; } = string.Empty;

        public string CannonDamage { get; set; } = string.Empty;

        public string PirateDamage { get; set; } = string.Empty;

        public string Manueverability { get; set; } = string.Empty;

        public string ComparativeSpeed { get; set; } = string.Empty;

        public int Crew { get; set; }

        public int MinCrew { get; set; }

        public int IdealCrew { get; set; }

        public int InoperableCrew { get; set; }

        public int CrippledCrew { get; set; }

        public int FunctionalCrew { get; set; }

        public string Durability { get; set; } = string.Empty;

        public int DurabilityCounter { get; set; }

        public int SalePrice { get; set; }

        public string TypeName { get; set; } = string.Empty;

        public string[]? Notes { get; set; } = [];

        public int MaxCannons { get; set; } = 0;

        public int MaxCrew { get; set; } = 0;

        public int CargoCapacity { get; set; } = 0;

        public bool HasNotes()
        {
            return Notes?.Length != 0;
        }
    }
}
