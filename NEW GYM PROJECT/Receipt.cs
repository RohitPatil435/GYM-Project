using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NEW_GYM_PROJECT
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtresult.Clear();
            txtresult.Text += "************************************\n";
            txtresult.Text += "***          FEES RECEIPT           ***\n";
            txtresult.Text += "************************************\n";
            txtresult.Text += "Date :" + DateTime.Now + "\n\n";

            txtresult.Text += "Name : " + PNameTb.Text + "\n\n";
            txtresult.Text += "MobileNo :" + PPhoneTb.Text + "\n\n";
            txtresult.Text += "Batch Time :" + PTimeCB.Text + "\n\n";
            txtresult.Text += "Fees :" + PFeesTb.Text + "\n\n";

            txtresult.Text += "\n                                    signature"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PNameTb.Text = "";
            PPhoneTb.Text = "";
            PTimeCB.Text = "";
            PFeesTb.Text = "";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtresult.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
