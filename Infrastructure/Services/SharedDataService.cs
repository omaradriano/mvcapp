namespace Services
{
    public class SharedDataService
    {
        private string _username;
        private string _code;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string Code
        {
            get => _code;
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        // El evento que se dispara cuando los datos cambian
        public event EventHandler OnDataChanged;
    }
}
