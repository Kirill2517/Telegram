﻿using generator.logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://random-word-api.herokuapp.com/word?number=100
namespace generator
{
    class Program
    {
        static readonly Random random = new Random((int)DateTime.Now.Millisecond);
        class myThread
        {
            Thread thread;

            public myThread() //Конструктор получает имя функции и номер до кторого ведется счет
            {
                thread = new Thread(func);
                thread.Start();
            }

            void func()
            {
                
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                object u = null;
                string url = "";
                switch (random.Next(0, 2))
                {
                    case 0:
                        u = GenerateApplicant.GetApplicant();
                        url = "appl";
                        break;
                    case 1:
                        u = GenerateEmployer.GetEmployer();
                        url = "empl";
                        break;
                    default:
                        break;
                }
                var user = new { User = u, password = "123456", fingerprint = Guid.NewGuid().ToString() };
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var client = new HttpClient();
                var data = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var res = client.PostAsync($"http://localhost:5000/api/auth/signup/{url}", data);
                string result = res.Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(stopwatch.Elapsed + $"\t{result}");
                stopwatch.Stop();
            }
        }
    }
}
