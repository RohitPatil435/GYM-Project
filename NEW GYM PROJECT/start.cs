using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEW_GYM_PROJECT
{
    public partial class start : Form
    {
        int startpoint = 0;
        public start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                login login = new login();
                login.Show();
                this.Hide();
            }
        }

        private void start_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
