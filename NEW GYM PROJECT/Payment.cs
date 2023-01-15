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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-D0PN2OJD\MYSQL;Initial Catalog=Gymdbs;Integrated Security=True");
        int ID;
        
        private void Payment_Load(object sender, EventArgs e)
        {
            GetEqdata();
        }
        private void GetEqdata()
        {
            SqlCommand cmd = new SqlCommand("select * from paymenttbl", Con);
            DataTable dt = new DataTable();
            Con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            paydgv.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Valid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO paymenttbl VALUES (@MainId,@MName,@MPhoneN,@MMonthlyFees,@MPaidFees,@MRemainingFees)", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MainId", pid.Text);
                cmd.Parameters.AddWithValue("@MName", pname.Text);
                cmd.Parameters.AddWithValue("@MPhoneN", pphone.Text);
                cmd.Parameters.AddWithValue("@MMonthlyFees", pmamount.Text);
                cmd.Parameters.AddWithValue("@MPaidFees", paidamt.Text);
                cmd.Parameters.AddWithValue("@MRemainingFees", ramt.Text);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("Fees paid successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEqdata();
                Clearform();
            }
        }

        private bool Valid()
        {
            if (pid.Text == string.Empty)
            {
                MessageBox.Show("Id is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ID = 0;
            pid.Text = "";
            pname.Text = "";
            pphone.Text = "";
            pmamount.Text = "";
            paidamt.Text = "";
            ramt.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ID> 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE paymenttbl SET MainId=@MainId,MName=@MName,MPhoneN=@MPhoneN,MMonthlyFees=@MMonthlyFees,MPaidFees=@MPaidFees,MRemainingFees=@MRemainingFees WHERE ID=@ID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MainId", pid.Text);
                cmd.Parameters.AddWithValue("@MName", pname.Text);
                cmd.Parameters.AddWithValue("@MPhoneN", pphone.Text);
                cmd.Parameters.AddWithValue("@MMonthlyFees", pmamount.Text);
                cmd.Parameters.AddWithValue("@MPaidFees", paidamt.Text);
                cmd.Parameters.AddWithValue("@MRemainingFees", ramt.Text);
                cmd.Parameters.AddWithValue("@ID", this.ID);

                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("Fees successfully updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEqdata();
                Clearform();
            }
            else
            {
                MessageBox.Show("Select ID to update", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM paymenttbl WHERE ID=@ID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.ID);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("Member is successfully DELETED", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetEqdata();
                Clearform();
            }
            else
            {
                MessageBox.Show("Select Member to delete", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paydgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(paydgv.SelectedRows[0].Cells[0].Value);
            pid.Text = paydgv.SelectedRows[0].Cells[1].Value.ToString();
            pname.Text = paydgv.SelectedRows[0].Cells[2].Value.ToString();
            pphone.Text = paydgv.SelectedRows[0].Cells[3].Value.ToString();
            pmamount.Text = paydgv.SelectedRows[0].Cells[4].Value.ToString();
            paidamt.Text = paydgv.SelectedRows[0].Cells[5].Value.ToString();
            ramt.Text = paydgv.SelectedRows[0].Cells[6].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }
    }
}
