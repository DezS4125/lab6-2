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
        int position;
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
            try
            {
                string strInsert = "insert into canbo values (@maCb, @tenCB, @chucvuCB, @soGioGiang, @donGia)";
                clsDatabase.openConnection();
                SqlCommand con = new SqlCommand(strInsert, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@maCb", SqlDbType.Int);
                p1.Value = mscb;
                SqlParameter p2 = new SqlParameter("@tenCB", SqlDbType.NVarChar);
                p2.Value = name;
                SqlParameter p3 = new SqlParameter("@chucvuCB", SqlDbType.Int);
                p3.Value = position;
                SqlParameter p4 = new SqlParameter("@soGioGiang", SqlDbType.Int);
                p4.Value = hour;
                SqlParameter p5 = new SqlParameter("@donGia", SqlDbType.Money);
                p5.Value = price;

                con.Parameters.Add(p1);
                con.Parameters.Add(p2);
                con.Parameters.Add(p3);
                con.Parameters.Add(p4);
                con.Parameters.Add(p5);
                con.ExecuteNonQuery();
                MessageBox.Show("Insert successfully!!!");
                clsDatabase.closeConnection();
                clearAllField();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnAdd.Enabled = true;
            btnSave.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            name = txtName.Text;
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPosition.SelectedIndex == -1) return;
            position = Convert.ToInt32(cbPosition.SelectedValue);
        }

        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            if (txtHour.Text == "") return;
            try
            {
                hour = Convert.ToInt32(txtHour.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Hour must be integer");
                txtHour.Clear();
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text == "") return;
            try
            {
                price = Convert.ToInt32(txtPrice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Price must be integer");
                txtPrice.Clear();
            }

        }
    }
}
