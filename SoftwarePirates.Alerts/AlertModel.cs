namespace SoftwarePirates.Alerts
{
    public class AlertModel : IAlertModel
    {
        public string AlertType { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Index { get; set; }
    }
}
