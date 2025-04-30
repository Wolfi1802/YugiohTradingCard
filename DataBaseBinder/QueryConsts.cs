using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseBinder
{
    public class QueryConsts
    {
        public const string SELECT_ALL_ = "SELECT * FROM ";

        #region DB zusammenabuen

        public const string CREATE_TABLE_CARDS = @"CREATE TABLE IF NOT EXISTS `Cards` (
        `ID` int NOT NULL AUTO_INCREMENT PRIMARY KEY
        );";

        public const string CREATE_TABLE_CUSTOMERS = @"CREATE TABLE IF NOT EXISTS `Customers` (
        `ID` int NOT NULL AUTO_INCREMENT PRIMARY KEY
        );";

        #endregion
    }
}
