namespace SoftwarePirates
{
    public interface IFleetBuilderEngine
    {
        string ExportText { get; }
        IEnumerable<IShipBattleModel> FleetBattleModels { get; }
        int FleetBudget { get; }
        IEnumerable<IShipDisplayModel> FleetDisplayModels { get; }
        int FleetExpense { get; }
        string FleetName { get; set; }
        string ImportText { get; set; }
        int RemainingBudget { get; }
        IShipEditModel ShipEdit { get; }
        IEnumerable<string> ShipTypeOptions { get; }

        void AddShipToFleet();
        void ImportFleet();
        bool IsOverBudget();
    }
}