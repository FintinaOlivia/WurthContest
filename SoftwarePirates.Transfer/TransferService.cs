namespace SoftwarePirates.Transfer
{
    public class TransferService : ITransferService
    {
        public string GenerateExportText(string fleetName, IEnumerable<IShipDisplayModel> shipDisplayModels)
        {
            string exportText = $"{fleetName}\n";
            foreach (var ship in shipDisplayModels)
            {
                exportText += $"{ship.Name}|{ship.ShipType}|{ship.Cannons}|{ship.Crew}|{ship.Modifiers}\n";
            }
            return exportText;
        }

        public ImportResult GetImportResult(string importText)
        {
            string fleetName = string.Empty;
            List<string> errors = [];
            List<ShipLine> shipLines = [];

            if (!string.IsNullOrWhiteSpace(importText))
            {
                string[] lines = importText.Split("\n");

                fleetName = lines[0];

                if (lines.Length > 1)
                {
                    for (int n = 1; n < lines.Length; n++)
                    {
                        if (lines[n] == "") continue;

                        string[] parts = lines[n].Split("|");
                        if (parts.Count() == 5)
                        {
                            int cannons = int.TryParse(parts[2], out int j) ? j : 0;
                            int crew = int.TryParse(parts[3], out int k) ? k : 0;
                            shipLines.Add(new ShipLine
                            {
                                Name = parts[0],
                                ShipType = parts[1],
                                Cannons = cannons,
                                Crew = crew,
                                Modifiers = parts[4]
                            });
                        }
                        else
                        {
                            errors.Add($"Could not import \"{lines[n]}\"");
                        }
                    }
                }
            }

            return new ImportResult
            {
                FleetName = fleetName,
                LineErrors = [.. errors],
                ShipLines = [.. shipLines],
            };
        }
    }
}
