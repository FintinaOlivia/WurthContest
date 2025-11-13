using SoftwarePirates.Domain.Modifiers;

namespace SoftwarePirates.Domain
{
    public class Ship : IShipBattleModel, IShipDisplayModel, IShipTypeCardModel
    {
        public string ApIcon { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Cost { get; set; }

        public string ShipType { get; set; } = string.Empty;

        private PhysicalSizes _physicalSize;
        public PhysicalSizes PhysicalSizes
        {
            get => _physicalSize;
            set => _physicalSize = value;
        }

        public string PhysicalSize => _physicalSize.GetDescription();

        public string Modifiers { get; set; } = string.Empty;

        public int Cannons { get; set; }

        private CannonAccuracies _cannonAccuracy; 
        public CannonAccuracies CannonAccuracies
        { 
            get => _cannonAccuracy; 
            set => _cannonAccuracy = value; 
        }
        public string CannonAccuracy => _cannonAccuracy.GetDescription();

        private CannonDamages _cannonDamage;
        public CannonDamages CannonDamages
        {
            get => _cannonDamage;
            set => _cannonDamage = value;
        }
        public string CannonDamage => _cannonDamage.GetDescription();

        private PirateDamages _pirateDamage;
        public PirateDamages PirateDamages
        {
            get => _pirateDamage;
            set => _pirateDamage = value;
        }

        public string PirateDamage => _pirateDamage.GetDescription();


        private Maneuverabilities _manueverability;
        public Maneuverabilities Manueverabilities
        {
            get => _manueverability;
            set => _manueverability = value;
        }

        public string Manueverability => _manueverability.GetDescription();


        private ComparativeSpeeds _comparativeSpeed;
        public ComparativeSpeeds ComparativeSpeeds
        {
            get => _comparativeSpeed;
            set => _comparativeSpeed = value;
        }

        public string ComparativeSpeed => _comparativeSpeed.GetDescription();

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

        public (bool Reinforced, bool BigGuns, bool Elite)  ModifierList { get; set; } = (false, false, false);

        public bool HasNotes()
        {
            return Notes?.Length > 0;
        }
    }
}
