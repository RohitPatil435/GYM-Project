using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEW_GYM_PROJECT
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100,0,0,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Enter user name and password");
            }
            else if (user.Text == "Admin" && pass.Text == "12345")
            {
                this.Hide();
                mainform m = new mainform();
                m.Show();
            }
            else
            {
                MessageBox.Show("Wrong user and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user.Text = "";
            pass.Text = "";
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
