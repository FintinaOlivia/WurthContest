namespace SoftwarePirates.Alerts
{
    public class AlertEngine : IAlertEngine
    {
        private const string DANGER = "danger";
        private const string SUCCESS = "success";

        private List<Tuple<string, string>> _messages { get; set; } = new List<Tuple<string, string>>();

        public IEnumerable<IAlertModel> AlertMessages
        {
            get
            {
                return _messages.Select(x => new AlertModel
                {
                    AlertType = x.Item1,
                    Message = x.Item2,
                    Index = _messages.IndexOf(x)
                });
            }
        }

        public void AddDangerMessage(string message)
        {
            _messages.Add(new Tuple<string, string>(DANGER, message));
        }

        public void AddSuccessMessage(string message)
        {
            _messages.Add(new Tuple<string, string>(SUCCESS, message));
        }

        public void ClearMessages()
        {
            _messages = new List<Tuple<string, string>>();
        }

        public void RemoveMessage(int n)
        {
            _messages.RemoveAt(n);
        }
    }
}
