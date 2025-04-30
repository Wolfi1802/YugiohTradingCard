using MySql.Data.MySqlClient;
using System.Data;

namespace DataBaseBinder
{
    internal class QueryExecuter
    {
        //TODO[TS] Logging
        private string? DbConnectionString = null;

        public QueryExecuter(string connection)
        {
            try
            {
                this.DbConnectionString = connection;
            }
            catch (Exception ex)
            {
            }
        }


        public List<DataTable>? GetAllContentFromDatabase(string databaseName)
        {
            List<DataTable> listOftables = new List<DataTable>();

            string queryString = $"SELECT table_name " +
                $"FROM information_schema.tables " +
                $"WHERE table_type='BASE TABLE' " +
                $"AND table_schema = '{databaseName}'";

            var result = this.Execute(queryString);
            try
            {

                if (result != null)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        string tableName = row.ItemArray[0].ToString();

                        var tableResult = this.GetSelectTable(tableName, databaseName);

                        if (tableResult != null)
                            listOftables.Add(tableResult);
                    }

                    return listOftables;
                }
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// Holt sich alle informationen ohne Einschränkung aus der db <paramref name="databaseName"/> bzw. der Tabelle <paramref name="tableName"/>
        /// </summary>
        /// <param name="tableName">Name der Tabelle</param>
        /// <param name="databaseName">Name der Datenbank</param>
        /// <returns>Gibt die Ergebnisse zurück</returns>
        public DataTable? GetSelectTable(string tableName, string databaseName)
        {
            string queryString = $"{QueryConsts.SELECT_ALL_} {databaseName}.{tableName};";

            return this.Execute(queryString);
        }

        /// <summary>
        /// Führt den Query <paramref name="queryString"/> auf Basis der DB <paramref name="DbConnectionString"/> aus.
        /// </summary>
        /// <param name="queryString">Query der ausgeführt werden soll</param>
        /// <returns>Ergebniss des Querys</returns>
        public DataTable? Execute(string queryString)
        {
            using (MySqlConnection connection = new MySqlConnection(this.DbConnectionString))//[TS] Hier machen wir immer eine neue instanz, da die Verbindung nicht wiederverwendet werden kann, weuil sie nach einem Query automatisch disposed wird.
            {
                try
                {
                    connection.Open();
                    
                    MySqlDataAdapter adr = new MySqlDataAdapter(queryString, connection);
                    adr.SelectCommand.CommandType = CommandType.Text;
                    DataTable actualldata = new DataTable();
                    adr.Fill(actualldata);

                    return actualldata;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Baut die Datenbank in einer bestimmten Reihenfolge auf.
        /// </summary>
        public void BuildDataBase()
        {
            this.Execute(QueryConsts.CREATE_TABLE_CARDS);
            this.Execute(QueryConsts.CREATE_TABLE_CUSTOMERS);
        }


    }
}

