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
using Household_Ledger.Code_Cls;

namespace Household_Ledger
{
    public partial class Common_Code : Form
    {
        private OleDbConnection oleDb;

        public Common_Code()
        {
            InitializeComponent();

            oleDb = MDIParent1.oleDB;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list_setting();
            button1_Click(sender, e);
        }

        public void list_setting()
        {
            string sql = "SELECT * FROM COMMON_CODE ORDER BY COMM_GRP ASC, COMM_CD ASC";
            DataSet ds = DataBaseHelper.OleExecuteReader(sql, oleDb);

            IList<Common_code> comm_codes = (from row in ds.Tables[0].AsEnumerable()
                                             select new Common_code
                                             {
                                                 Id = row.Field<int>("id"),
                                                 Comm_grp = row.Field<string>("comm_grp"),
                                                 Comm_cd = row.Field<string>("comm_cd"),
                                                 Comm_nm = row.Field<string>("comm_nm"),
                                                 Use_yn = row.Field<string>("use_yn")
                                             }).ToList<Common_code>();

            listBox1.DisplayMember = "COMM_DISPLAY";
            listBox1.ValueMember = "ID";
            listBox1.DataSource = comm_codes;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common_code selCcode = (Common_code)listBox1.SelectedItem;

            label2.Text = selCcode.Id.ToString();
            textBox1.Text = selCcode.Comm_grp.ToString();
            textBox2.Text = selCcode.Comm_cd.ToString();
            textBox3.Text = selCcode.Comm_nm.ToString();
            if (selCcode.Use_yn.ToString() == "Y")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uSql = string.Format("UPDATE COMMON_CODE SET COMM_GRP = '{1}', COMM_CD = '{2}', COMM_NM = '{3}', USE_YN = '{4}', UPDATE_DT = '{5}' WHERE ID = {0}",
                label2.Text, textBox1.Text, textBox2.Text, textBox3.Text, ((checkBox1.Checked == true) ? "Y" : "N"), DateTime.Now.ToString("yyyy-MM-dd"));

            string iSql = string.Format("INSERT INTO COMMON_CODE (COMM_GRP, COMM_CD, COMM_NM, USE_YN, INSERT_DT) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                textBox1.Text, textBox2.Text, textBox3.Text, ((checkBox1.Checked == true) ? "Y" : "N"), DateTime.Now.ToString("yyyy-MM-dd"));
            int result = 0;

            if (label2.Text == "")
            {
                if (MessageBox.Show("새로운 코드를 등록 하시겠습니까 ?", "코드등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    result = DataBaseHelper.OleExecuteNonQuery(iSql, oleDb);
                }
            }
            else
            {
                if (MessageBox.Show("해동 코드를 수정 하시겠습니까 ?", "코드등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    result = DataBaseHelper.OleExecuteNonQuery(uSql, oleDb);
                }
            }

            list_setting();

            if (result == 1)
            {
                button1_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list_setting();
        }
    }

    class Common_code
    {
        public Common_code()
        {
        }

        public Common_code(int id, string comm_grp, string comm_cd, string comm_nm, string use_yn)
        {
            Id = id;
            Comm_grp = comm_grp;
            Comm_cd = comm_cd;
            Comm_nm = comm_nm;
            Use_yn = use_yn;
        }

        public int Id { get; set; }
        public string Comm_grp { get; set; }
        public string Comm_cd { get; set; }
        public string Comm_nm { get; set; }
        public string Use_yn { get; set; }

        public string comm_display
        {
            get
            {
                return string.Format("Group : {0} | Code : {1} | Name : {2} | Use : {3}", (object)this.Comm_grp, (object)this.Comm_cd, (object)this.Comm_nm, (object)this.Use_yn);
            }
        }
    }
}
