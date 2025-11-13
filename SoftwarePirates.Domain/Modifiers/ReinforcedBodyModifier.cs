namespace SoftwarePirates.Domain.Modifiers
{
    internal class ReinforcedBodyModifier : BaseModifier
    {
        public override int GetShipBodyPrice(int basePrice)
        {
           var baseCost = base.GetShipBodyPrice(basePrice);
            return (int)Math.Round(baseCost * 1.1);
        }
    }
}
