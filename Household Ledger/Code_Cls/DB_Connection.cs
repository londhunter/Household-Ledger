using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Household_Ledger.Code_Cls
{
    class DB_Connection
    {
        private static OleDbConnection OleCon;

        public DB_Connection(string connStr)
        {
            OleCon = new OleDbConnection(connStr);
        }

        public static OleDbConnection oleCon
        {
            get
            {
                return OleCon;
            }
        }
    }
}
