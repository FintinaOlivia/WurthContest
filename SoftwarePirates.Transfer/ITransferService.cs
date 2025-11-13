
namespace SoftwarePirates.Transfer
{
    public interface ITransferService
    {
        string GenerateExportText(string fleetName, IEnumerable<IShipDisplayModel> shipDisplayModels);
        ImportResult GetImportResult(string importText);
    }
}