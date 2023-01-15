using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEW_GYM_PROJECT
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addmembers addmembers = new addmembers();
            addmembers.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatedelete updatedelete = new updatedelete();
            updatedelete.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            addmembers addmembers = new addmembers();
            addmembers.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updatedelete updatedelete = new updatedelete();
            updatedelete.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            equipment.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            equipment.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Receipt fees = new Receipt();
            fees.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Receipt fees = new Receipt();
            fees.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
            this.Hide();
        }
    }
}
