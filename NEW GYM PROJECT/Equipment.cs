using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NEW_GYM_PROJECT
{
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-D0PN2OJD\MYSQL;Initial Catalog=Gymdbs;Integrated Security=True");
        int EId;
        private void Equipment_Load(object sender, EventArgs e)
        {
            GetEqdata();
        }

        private void GetEqdata()
        {
            SqlCommand cmd = new SqlCommand("select * from eqtbl", Con);
            DataTable dt = new DataTable();
            Con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            eqadddgv.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO eqtbl VALUES (@EName,@EQuantity,@EAmount)", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EName", eqname.Text);
                cmd.Parameters.AddWithValue("@EQuantity", eqquantity.Text);
                cmd.Parameters.AddWithValue("@EAmount", eqamount.Text);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("New equipment is successfully added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEqdata();
                Clearform();
            }
        }

        private bool Valid()
        {
            if (eqname.Text == string.Empty)
            {
                MessageBox.Show("equipment name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clearform();
        }

        private void Clearform()
        {
            EId = 0;
            eqname.Text = "";
            eqquantity.Text = "";
            eqamount.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (EId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE eqtbl SET EName=@EName,EQuantity=@EQuantity,EAmount=@EAmount WHERE EId=@EId", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EName", eqname.Text);
                cmd.Parameters.AddWithValue("@EQuantity", eqquantity.Text);
                cmd.Parameters.AddWithValue("@EAmount", eqamount.Text);
                cmd.Parameters.AddWithValue("@EId", this.EId);

                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("equipment is successfully updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEqdata();
                Clearform();
            }
            else
            {
                MessageBox.Show("Select equipment to update", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (EId > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM eqtbl WHERE EId=@EId", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EID", this.EId);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("equipment is successfully DELETED", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEqdata();
                Clearform();
            }
            else
            {
                MessageBox.Show("Select equipment to delete", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eqadddgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EId = Convert.ToInt32(eqadddgv.SelectedRows[0].Cells[0].Value);
            eqname.Text = eqadddgv.SelectedRows[0].Cells[1].Value.ToString();
            eqquantity.Text = eqadddgv.SelectedRows[0].Cells[2].Value.ToString();
            eqamount.Text = eqadddgv.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }
    }
}
