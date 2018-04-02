using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Household_Ledger
{
    public partial class Form1 : Form
    {
        private OleDbConnection oleDb;

        public Form1()
        {
            InitializeComponent();

            oleDb = MDIParent1.oleDB;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "Select * FROM COMMON_CODE";
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(sql, oleDb);

            cmd.CommandText = sql;

            OleDbDataReader reader = cmd.ExecuteReader();
            OleDbDataAdapter oleAdap = new OleDbDataAdapter(sql, oleDb);

            oleAdap.Fill(ds);

            listBox1.Items.Clear();

            listBox1.DisplayMember = "COMM_NM";
            listBox1.ValueMember = "COMM_CD";
            listBox1.DataSource = ds.Tables[0];
        }
    }
}
