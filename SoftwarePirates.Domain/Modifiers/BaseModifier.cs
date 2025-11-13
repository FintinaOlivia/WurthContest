namespace SoftwarePirates.Domain.Modifiers
{
    public class BaseModifier
    {
        public virtual int GetShipBodyPrice(int basePrice) 
        {
            return basePrice;
        }

        public virtual int GetFirePowerCost()
        {
            return Constants.CANNONSTANDARDCOST;
        }

        public virtual int GetCrewCost()
        {
            return Constants.CREWSTANDARDCOST;
        }
    }
}
