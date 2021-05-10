using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generatorView.panels
{
    public partial class DeletePanel : UserControl
    {
        public DeletePanel()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Начато удаление";
            HttpClient client = new HttpClient();
            string requestUri = $"{Settings.baseurl}debugguider/common/deleterecords";
            var res = await client.DeleteAsync(requestUri);
            File.WriteAllText(@"accounts.json", string.Empty);
            label1.Text = res.StatusCode.ToString();
        }
    }
}
