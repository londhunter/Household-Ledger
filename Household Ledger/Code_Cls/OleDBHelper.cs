using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Household_Ledger.Code_Cls
{
    public sealed class DataBaseHelper
    {
        private DataBaseHelper() {}

        public static DataSet OleExecuteReader(string sql, OleDbConnection conn)
        {
            DataSet tData = new DataSet();
            OleDbDataAdapter oAdap = new OleDbDataAdapter(sql, conn);

            oAdap.Fill(tData);

            return tData;
        }

        public static int OleExecuteNonQuery(string sql, OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            return cmd.ExecuteNonQuery();
        }
    }
}
