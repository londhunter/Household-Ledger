using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Household_Ledger.Code_Cls
{
    class OleDBConn
    {
        private static OleDbConnection OleCon;

        public OleDBConn(string connStr)
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
