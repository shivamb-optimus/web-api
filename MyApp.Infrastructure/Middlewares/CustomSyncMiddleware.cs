using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyApp.Infrastructure.Middlewares
{
    public class CustomSyncMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomSyncMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            Console.WriteLine("In the pre-processing part");

            Console.WriteLine(context);

            _next(context);

            Console.WriteLine("In the post-processing part");

            return Task.CompletedTask;
        }
    }
}
