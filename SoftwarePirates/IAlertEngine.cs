namespace SoftwarePirates
{
    public interface IAlertEngine
    {
        public IEnumerable<IAlertModel> AlertMessages { get; }
        void AddDangerMessage(string message);
        void AddSuccessMessage(string message);
        void ClearMessages();
        void RemoveMessage(int n);
    }
}
