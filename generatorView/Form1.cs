using generatorView.panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generatorView
{
    public partial class Form1 : Form
    {
        private UserControl currentPanel;
        public Form1()
        {
            InitializeComponent();
        }

        public void SetCurrent(UserControl userControl)
        {
            splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(userControl);
            userControl.Visible = true;
            currentPanel = userControl;
            currentPanel.Dock = DockStyle.Fill;
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrent(new DeletePanel());
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrent(new SingUpPanel());
        }
    }
}
