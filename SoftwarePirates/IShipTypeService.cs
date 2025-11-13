namespace SoftwarePirates
{
    public interface IShipTypeService
    {
        IEnumerable<IShipTypeCardModel> GetCards();
    }
}
