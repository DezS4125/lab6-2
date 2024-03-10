using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_2_again
{
    public partial class Form1 : Form
    {
        int mscb;
        string name;
        string position;
        int hour;
        int price;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qlcbDataSet.chucvu' table. You can move, or remove it, as needed.
            this.chucvuTableAdapter.Fill(this.qlcbDataSet.chucvu);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void clearAllField()
        {
            txtMSCB.Clear();
            txtHour.Clear();
            txtName.Clear();
            txtPrice.Clear();
            cbPosition.SelectedIndex = -1;
            txtName.Focus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clsDatabase.openConnection();
                SqlCommand com = new SqlCommand("select max(maCB) from canbo", clsDatabase.con);
                mscb = Convert.ToInt32(com.ExecuteScalar());
                clsDatabase.closeConnection();

            }
            catch (Exception)
            {
                mscb = 0;
            }
            mscb++;
            clearAllField();
            txtMSCB.Text = mscb.ToString();
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            btnAdd.Enabled = true;
            btnSave.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
