using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseBinder
{
    internal class DBConnector
    {
        private Dictionary<string, MySqlConnection> connections = new Dictionary<string, MySqlConnection>();

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
            MySqlConnection yuGiYohTradingCards = new MySqlConnection($"server=localhost;user id=root;password=;database={DB_NAME};");

            this.connections.Add(DB_NAME, yuGiYohTradingCards);
        }

        public MySqlConnection? GetConnection(string dataBaseName)
        {
            foreach (var item in this.connections)
            {
                if (item.Key.Equals(dataBaseName))
                    return item.Value;
            }

            return null;
        }

        public Dictionary<string, MySqlConnection> GetAllConnections()
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
                this.connections.Add(database, new MySqlConnection($"server={server};user id={userId};password={password};database={database};"));
        }
    }
}
