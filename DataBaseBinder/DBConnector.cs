namespace DataBaseBinder
{
    internal class DBConnector
    {
        private Dictionary<string, string> connections = new Dictionary<string, string>();

        private static DBConnector _instance;
        public static DBConnector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DBConnector();

                return _instance;
            }
        }

        internal const string DB_NAME = "YuGiYohTradingCards";
        private DBConnector()
        {
            string yuGiYohTradingCards = $"server=localhost;user id=root;password=;database={DB_NAME};";

            this.connections.Add(DB_NAME, yuGiYohTradingCards);
        }

        public string? GetConnection(string dataBaseName)
        {
            foreach (var item in this.connections)
            {
                if (item.Key.Equals(dataBaseName))
                    return item.Value;
            }

            return null;
        }

        public Dictionary<string, string> GetAllConnections()
        {
            return this.connections;
        }

        public void AddConnection(string server, string userId, string database, string password = "")
        {
            if (string.IsNullOrEmpty(server))
                throw new NullReferenceException($" Hinzufügen nicht möglich weil [{server}] == null");
            if (string.IsNullOrEmpty(userId))
                throw new NullReferenceException($" Hinzufügen nicht möglich weil [{userId}] == null");
            if (string.IsNullOrEmpty(database))
                throw new NullReferenceException($" Hinzufügen nicht möglich weil [{database}] == null");

            if (!this.connections.ContainsKey(database))
                this.connections.Add(database, $"server={server};user id={userId};password={password};database={database};");
        }
    }
}
