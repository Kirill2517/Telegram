using generator.entity;
using generator.logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generatorView.panels
{
    public partial class SingUpPanel : UserControl
    {

        public SingUpPanel()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            log.Text = "начато";
            UserGenerator userGenerator = new UserGenerator((int)numericUpDown1.Value, applicant.Checked, employer.Checked);
            await userGenerator.StartGen();
            log.Text = "закончено";
        }
    }
    class ExistUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public string deviceId { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public DateTime expires { get; set; }

    }

    class UserGenerator
    {
        private int Count { get; }
        private bool GenAppl { get; }
        private bool GenEmpl { get; }
        private List<ExistUser> exists = new List<ExistUser>();
        public UserGenerator(int count, bool genAppl, bool genEmpl)
        {
            Count = count;
            GenAppl = genAppl;
            GenEmpl = genEmpl;
        }

        public async Task StartGen()
        {
            if (GenEmpl)
                for (int i = 0; i < Count / 2; i++)
                {
                    await Generate(GenerateEmployer.GetEmployer(), "employer");
                }

            if (GenAppl)
                for (int i = 0; i < Count / 2; i++)
                {
                    await Generate(GenerateApplicant.GetApplicant(), "applicant");
                }

            using (StreamReader reader = new StreamReader(@"accounts.json", Encoding.Default))
            {
                var ex = JsonConvert.DeserializeObject<List<ExistUser>>(reader.ReadToEnd());
                if (ex != null)
                    exists.AddRange(ex);
            }
            using (StreamWriter file = new StreamWriter(@"accounts.json", false))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, exists);
            }
        }

        private async Task Generate(User u, string url)
        {
            var deviceId = Guid.NewGuid().ToString();
            var password = "123456";
            var user = new { User = u, password, deviceId };
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var client = new HttpClient();
            var data = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var res = await client.PostAsync($"http://localhost:5000/api/auth/signup/{url}", data);
            stopwatch.Stop();
            string result = await res.Content.ReadAsStringAsync();
            Console.WriteLine(stopwatch.Elapsed + $"\t{result}");
            var exist = JsonConvert.DeserializeObject<ExistUser>(result);
            if (exist.access_token != null)
            {
                exist.password = password;
                exist.deviceId = deviceId;
                exists.Add(exist);
            }

        }
    }

}
