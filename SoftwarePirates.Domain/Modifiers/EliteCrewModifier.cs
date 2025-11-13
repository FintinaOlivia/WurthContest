namespace SoftwarePirates.Domain.Modifiers
{
    internal class EliteCrewModifier : BaseModifier
    {
        public override int GetCrewCost()
        {
            return Constants.BIGGUNSCOST;
        }
    }
}
