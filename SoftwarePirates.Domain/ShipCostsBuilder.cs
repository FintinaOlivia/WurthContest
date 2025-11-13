namespace SoftwarePirates.Domain
{
    public class ShipCostBuilder
    {
        private readonly int _baseCost;
        private readonly int _cannons;
        private readonly int _crew;
        private bool _reinforced;
        private bool _bigGuns;
        private bool _eliteCrew;
        private readonly List<Func<int>> _costRules = new();

        public ShipCostBuilder(int baseCost, int cannons, int crew)
        {
            _baseCost = baseCost;
            _cannons = cannons;
            _crew = crew;
        }

        public ShipCostBuilder WithReinforced()
        {
            _reinforced = true;
            return this;
        }

        public ShipCostBuilder WithBigGuns()
        {
            _bigGuns = true;
            return this;
        }

        public ShipCostBuilder WithEliteCrew()
        {
            _eliteCrew = true;
            return this;
        }

        private int GetBaseCost() =>
            _reinforced ? (int)Math.Round(_baseCost * 1.1) : _baseCost;

        private int GetCannonCost() =>
            _bigGuns ? _cannons * 30 : _cannons * Constants.CANNONSTANDARDCOST;

        private int GetCrewCost() =>
            _eliteCrew ? _crew * 15 : _crew * Constants.CREWSTANDARDCOST;

        public int GetCost() => GetBaseCost() + GetCannonCost() + GetCrewCost();


    }

}
