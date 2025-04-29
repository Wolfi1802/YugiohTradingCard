using MySql.Data.MySqlClient;

namespace DataBaseBinder
{
    public class DBRepository
    {
        private static DBRepository dbRepository;
        public static DBRepository Instance
        {
            get
            {
                if (dbRepository is null)
                    dbRepository = new();

                return dbRepository;
            }
        }


        private DBConnector DBConnector { get { return DBConnector.Instance; } }

        private MySqlConnection? currentConnection = null;
        private DBRepository()
        {
            this.currentConnection = this.DBConnector.GetConnection(DBConnector.DB_NAME);
            QueryExecuter queryExecuter = new QueryExecuter(this.currentConnection);
            queryExecuter.BuildDataBase();
        }

        public void LoadDatas()
        {
            if (this.IsConnectionAvialable())
            {
                QueryExecuter queryExecuter = new QueryExecuter(this.currentConnection);

                var datas = queryExecuter.GetAllContentFromDatabase(DBConnector.DB_NAME);//[TS] TEST um daten zu beziehen
            }
        }

        private bool IsConnectionAvialable()
        {
            return this.currentConnection is not null;
        }
    }
}
