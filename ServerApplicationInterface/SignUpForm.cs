using System;
using System.Windows.Forms;

namespace ServerApplicationInterface
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void EmployerButton_Click(object sender, EventArgs e)
        {
            SignUpDataUserForm frm2 = new SignUpDataUserForm();
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
