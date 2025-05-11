using SmartMiddlewareKit.MIddleware.Extensions;
using SmartMiddlewareKit.Middleware.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middleware.Test
{
    public class AddTextFromOptionsMiddleware
    {
        readonly MiddlewareDelegate<TestContext> _next;
        readonly string _message;

        public AddTextFromOptionsMiddleware(MiddlewareDelegate<TestContext> next, string message)
        {
            _next = next;
            _message = message;
        }

        public Task InvokeAsync(TestContext context, AddTextFromOptionsMiddlewareOptions options)
        {

            context.Message.Append(_message);
            context.Message.AppendLine(options.Text);
            _next(context);
            return Task.CompletedTask;
        }
    }
}
