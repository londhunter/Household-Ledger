using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Household_Ledger.Code_Cls;
using System.Data.OleDb;

namespace Household_Ledger
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        public static OleDbConnection oleDB;

        public MDIParent1()
        {
            InitializeComponent();

            oleDB = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=../Household_Ledger.accdb;Mode=ReadWrite;");
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            oleDB.Close();
            this.Close();
        }

        private void 코드생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }
    }
}
