using System.Data;

namespace DataBaseBinder
{
    class QueryResultParser
    {
        /// <summary>
        /// Convertiert das Query Ergebniss <paramref name="queryResult"/> in eine Lesbare Tabelle als String
        /// </summary>
        /// <param name="queryResult">Ergebniss des Requests</param>
        /// <returns>Null => Fehler, sonst ein befüllter String</returns>
        public string? GetFormatedDataTable(DataTable queryResult)
        {
            var formateTable = this.ReadDataTable(queryResult);
            string headline = string.Empty;
            string tableValues = string.Empty;

            if (queryResult != null)
            {
                try
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
                catch (Exception ex)
                {
                }
            }

            return null;
        }

        /// <summary>
        ///  Convertiert das Query Ergebniss <paramref name="queryResult"/> in eine Lesbare Tabelle als String
        /// </summary>
        /// <param name="queryResult">Ergebniss des Requests</param>
        /// <returns>Null => Fehler, sonst eine befüllte Liste</returns>
        public List<List<(string, string)>>? ReadDataTable(DataTable queryResult)
        {
            try
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
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
