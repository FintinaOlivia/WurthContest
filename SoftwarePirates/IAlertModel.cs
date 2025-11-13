namespace SoftwarePirates
{
    public interface IAlertModel
    {
        public string AlertType { get; }
        public string Message { get; }
        public int Index { get; }
    }
}
