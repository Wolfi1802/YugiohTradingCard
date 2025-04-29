using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace DataBaseBinder
{
    internal class QueryExecuter
    {//TODO[TS] Logging
        private const string SELECT_ALL_ = "SELECT * FROM ";

        #region BD zusammenabuen

        private const string CREATE_TABLE_CARDS = @"CREATE TABLE `Cards` (
        `ID` int(11) NOT NULL AUTO_INCREMENT,
        PRIMARY KEY (`ID`)
        ) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;";

        #endregion

        private MySqlConnection DbConnection = null;
        private Exception currentException = null;
        public QueryExecuter(MySqlConnection connection)
        {
            try
            {
                this.DbConnection = connection;

                this.BuildDataBase();//TODO[TS] Check ob db schon vorhanden ist sonst erstellen, gibt aber probleme bei der connection...
            }
            catch (Exception ex)
            {
            }

        }

        public string GetFormatedDataTable(DataTable queryResult)
        {
            var formateTable = this.ReadDataTable(queryResult);
            string headline = string.Empty;
            string tableValues = string.Empty;

            if (queryResult != null)
            {
                foreach (var item in formateTable)
                {
                    foreach (var innerItem in item)
                    {
                        if (!headline.Contains(innerItem.Item1))
                            headline += $"{innerItem.Item1}".PadRight(10);

                        tableValues += $"{innerItem.Item2}".PadRight(10);
                    }

                    tableValues += "\n";
                }


                int tempHeaderLength = headline.Length;
                headline += "\n";

                for (int i = 0; i < tempHeaderLength; i++)
                {
                    headline += "_";
                }

                return $"```\n{queryResult.TableName}\n\n{headline}\n{tableValues}```";
            }
            else if (this.currentException != null)
                return this.currentException.Message;
            else
                return null;
        }

        public List<List<(string, string)>> ReadDataTable(DataTable queryResult)
        {
            if (queryResult != null)
            {
                List<List<(string, string)>> results = new List<List<(string, string)>>();

                foreach (DataRow row in queryResult.Rows)
                {
                    List<(string, string)> rowList = new List<(string, string)>();

                    foreach (var column in queryResult.Columns)
                    {
                        string value = row[column.ToString()].ToString();
                        rowList.Add((column.ToString(), value));
                    }
                    results.Add(rowList);
                }

                return results;
            }

            return null;
        }

        public List<DataTable> GetAllContentFromDatabase(string databaseName)
        {
            List<DataTable> listOftables = new List<DataTable>();

            string queryString = $"SELECT table_name " +
                $"FROM information_schema.tables " +
                $"WHERE table_type='BASE TABLE' " +
                $"AND table_schema = '{databaseName}'";

            var result = this.Execute(queryString);

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

            return null;
        }

        public DataTable GetSelectTable(string tableName, string databaseName)
        {
            string queryString = $"{SELECT_ALL_} {databaseName}.{tableName};";

            return this.Execute(queryString);
        }

        public DataTable Execute(string queryString)
        {
            this.currentException = null;

            using (MySqlConnection connection = this.DbConnection)
            {
                try
                {
                    connection.Open();//TODO[TS] rework, schlechter style die verbindung dauerhaft offen zu lassen

                    MySqlDataAdapter adr = new MySqlDataAdapter(queryString, connection);
                    adr.SelectCommand.CommandType = CommandType.Text;
                    DataTable actualldata = new DataTable();
                    adr.Fill(actualldata);


                    return actualldata;
                }
                catch (Exception ex)//TODO[TS] nach dem ersten Query : The connection had been disposed. 
                {
                    this.currentException = ex;

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void BuildDataBase()
        {
            this.Execute(CREATE_TABLE_CARDS);
        }

    }
}

