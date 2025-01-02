using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyApp.Infrastructure.Middlewares
{
    public class CustomAsyncMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAsyncMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("In the pre-processing part");

            //Console.WriteLine(context);

            await _next(context);

            Console.WriteLine("In the post-processing part");
        }
    }
}
