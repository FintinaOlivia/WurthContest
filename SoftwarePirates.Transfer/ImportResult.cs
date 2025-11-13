using System.Collections.Immutable;

namespace SoftwarePirates.Transfer
{
    public class ImportResult
    {
        public string FleetName { get; init; } = string.Empty;
        public ImmutableList<string> LineErrors { get; init; } = [];
        public ImmutableList<ShipLine> ShipLines { get; init; } = [];
    }
}
