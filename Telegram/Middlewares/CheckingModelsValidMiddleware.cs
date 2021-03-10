using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telegram.Middlewares
{
    public class CheckingModelsValidMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckingModelsValidMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

        }
    }
}
