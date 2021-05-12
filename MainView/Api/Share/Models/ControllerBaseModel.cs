using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Telegram.Api.Share.Models
{
    public class ControllerBaseModel : ControllerBase
    {
        public ControllerBaseModel(MySqlConnection connection)
        {
            Connection = connection;
        }

        public MySqlConnection Connection { get; set; }

        public Task<T> DiagnosticStopWatch<T>(Func<Task<T>> func)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = func();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            return result;
        }

        protected async Task<IActionResult> BaseFunction(Func<Task<IActionResult>> func)
        {
            if (ModelState.IsValid)
                return await func();
            else
                return BadRequest();
        }
    }
}
