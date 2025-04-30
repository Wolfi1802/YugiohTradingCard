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
        `ID` int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        `Name` varchar(20),
        `Email` varchar(50)
        );";

        public const string CREATE_TABLE_CUSTOMERS = @"CREATE TABLE IF NOT EXISTS `Customers` (
        `ID` int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        `Name` varchar(50),
        `ElementType` int(10)
        );";

        public const string CREATE_TABLE_CUSTOMERS_CARDS = @"create table if not exists `Customers_Cards`
(
`ID` int not null primary key,
`Cards_ID` int,
`Customers_ID` int,
CONSTRAINT FK_Customers_ID FOREIGN KEY (Customers_ID)
REFERENCES Customers(ID),
CONSTRAINT FK_Cards_ID FOREIGN KEY (Cards_ID)
REFERENCES Cards(ID)
);";

        #endregion
    }
}
