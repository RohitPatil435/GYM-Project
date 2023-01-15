using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEW_GYM_PROJECT
{
    public partial class updatedelete : Form
    {
        public updatedelete()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-D0PN2OJD\MYSQL;Initial Catalog=Gymdbs;Integrated Security=True");
        int MId;
        private void GetMemberRecords()
        {
         
            SqlCommand cmd = new SqlCommand("select * from membertbl", Con);
            DataTable dt = new DataTable();
            Con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            adddgv.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE membertbl SET MainID=@MainID,MName=@MName, MPhone=@MPhone, MAge=@MAge, MGender=@MGender, MAmount=@MAmount,MPaidAmount=@MPaidAmount,MJoindate=@MJoindate,MEnddate=@MEnddate,MTime=@MTime WHERE MId=@ID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MainID", uidtb.Text);
                cmd.Parameters.AddWithValue("@MName", unametb.Text);
                cmd.Parameters.AddWithValue("@MPhone", uphonetb.Text);
                cmd.Parameters.AddWithValue("@MAge", uagetb.Text);
                cmd.Parameters.AddWithValue("@MGender", ugendercb.Text);
                cmd.Parameters.AddWithValue("@MAmount", uamounttb.Text);
                cmd.Parameters.AddWithValue("@MPaidAmount", uadvtb.Text);
                cmd.Parameters.AddWithValue("@MJoindate", udatep.Text);
                cmd.Parameters.AddWithValue("@MEnddate",uedatep.Text);
                cmd.Parameters.AddWithValue("@MTime", utimecb.Text);
                cmd.Parameters.AddWithValue("@ID", this.MId);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("member is successfully updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetMemberRecords();
                resetformcontrol();
                
            }
            else
            {
                MessageBox.Show("Select Member to update", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void updatedelete_Load(object sender, EventArgs e)
        {
            GetMemberRecords();
        }
     
       
        private void button2_Click(object sender, EventArgs e)
        {
            resetformcontrol();
        }

        private void resetformcontrol()
        {
            MId = 0;
            uidtb.Text = "";
            unametb.Text = "";
            uphonetb.Text = "";
            uagetb.Text = "";
            ugendercb.Text = "";
            uamounttb.Text = "";
            uadvtb.Text = "";
            udatep.Text = "";
            uedatep.Text = "";
            utimecb.Text = "";

            uidtb.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MId>0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM membertbl WHERE MId=@ID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.MId);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("member is successfully DELETED", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetMemberRecords();
                resetformcontrol();
            }
            else
            {
                MessageBox.Show("Select Member to delete", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            
        }

        private void adddgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            MId = Convert.ToInt32(adddgv.SelectedRows[0].Cells[0].Value);
            uidtb.Text = adddgv.SelectedRows[0].Cells[1].Value.ToString();
            unametb.Text = adddgv.SelectedRows[0].Cells[2].Value.ToString();
            uphonetb.Text = adddgv.SelectedRows[0].Cells[3].Value.ToString();
            uagetb.Text = adddgv.SelectedRows[0].Cells[4].Value.ToString();
            ugendercb.Text = adddgv.SelectedRows[0].Cells[5].Value.ToString();
            uamounttb.Text = adddgv.SelectedRows[0].Cells[6].Value.ToString();
            uadvtb.Text = adddgv.SelectedRows[0].Cells[7].Value.ToString();
            udatep.Text = adddgv.SelectedRows[0].Cells[8].Value.ToString();
            uedatep.Text = adddgv.SelectedRows[0].Cells[9].Value.ToString();
            utimecb.Text = adddgv.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void adddgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uphonetb_TextChanged(object sender, EventArgs e)
        {

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
