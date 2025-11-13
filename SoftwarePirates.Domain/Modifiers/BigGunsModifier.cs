
namespace SoftwarePirates.Domain.Modifiers
{
    internal class BigGunsModifier : BaseModifier
    {
        public override int GetFirePowerCost()
        {
            return Constants.BIGGUNSCOST;
        }
    }
}
