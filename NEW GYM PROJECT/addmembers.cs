using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace NEW_GYM_PROJECT
{
    public partial class addmembers : Form
    {
        public addmembers()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-D0PN2OJD\MYSQL;Initial Catalog=Gymdbs;Integrated Security=True");

        private void addmembers_Load(object sender, EventArgs e)
        {
            GetMemberRecords();
        }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO membertbl VALUES (@MainID,@MName,@MPhone,@MAge,@MGender,@MAmount,@MPaidAmount,@MJoindate,@MEnddate,@MTime)", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MainID", idtxt.Text);
                cmd.Parameters.AddWithValue("@MName", MNameTb.Text);
                cmd.Parameters.AddWithValue("@MPhone", MPhoneTb.Text);
                cmd.Parameters.AddWithValue("@MAge", MAgeTb.Text);
                cmd.Parameters.AddWithValue("@MGender", MGenCB.Text);
                cmd.Parameters.AddWithValue("@MAmount", MAmountTb.Text);
                cmd.Parameters.AddWithValue("@MPaidAmount", MAdvTb.Text);
                cmd.Parameters.AddWithValue("@MJoindate", MDateP.Text);
                cmd.Parameters.AddWithValue("@MEnddate", MEdatep.Text);
                cmd.Parameters.AddWithValue("@MTime", MTimeCB.Text);

                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("New member is successfully added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetMemberRecords();
                Clearform();
            }
            
        }

        private bool IsValid()
        {
            if(MNameTb.Text==string.Empty)
            {
                MessageBox.Show("Member name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            idtxt.Text = "";
            MNameTb.Text = "";
            MPhoneTb.Text = "";
            MAgeTb.Text = "";
            MGenCB.Text = "";
            MAmountTb.Text = "";
            MAdvTb.Text = "";
            MDateP.Text = "";
            MEdatep.Text = "";
            MTimeCB.Text = "";

            idtxt.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainform mainform = new mainform();
            mainform.Show();
            this.Hide();
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

        private void adddgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
