﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApplicationInterface
{
    public partial class SignUpDataUserForm : Form
    {
        public SignUpDataUserForm()
        {
            InitializeComponent();
        }

        private void SignUpDataUserForm_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls.OfType<TextBox>())
            {
                item.SetWatermark(item.Name);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var newUser = new
                {
                    User = new
                    {
                        dataUser = new
                        {
                            email = emailTB.Text,
                            firstName = firstNameTB.Text,
                            middleName = middleNameTB.Text,
                            surname = surnameTB.Text,
                            phone = phoneTB.Text,
                            birthday = birthdayDTP.Value
                        },
                        idSex = idSex.Text,
                        idEducation = idEducation.Text,
                        idTypeEmployment = idTypeEmployment.Text,
                        desiredArea = desiredArea.Text
                    },
                    password = passwordTB.Text
                };
                JsonContent content = JsonContent.Create(newUser);
                MessageBox.Show(await content.ReadAsStringAsync());
                var str = await client.PostAsync("http://localhost:5000/api/auth/signup/appl", content);
                MessageBox.Show(await str.Content.ReadAsStringAsync());
            }
        }
    }
}