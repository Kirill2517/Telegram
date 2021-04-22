using System;
using System.Windows.Forms;

namespace ServerApplicationInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            SignUpForm frm2 = new SignUpForm();
            frm2.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
            frm2.Show();
            Hide();
        }

        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
