using SmartMiddlewareKit.MIddleware.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middleware.Test.Models
{
    public class AddTextMiddleware
    {
        readonly MiddlewareDelegate<TestContext> _next;
        readonly string _message;

        public AddTextMiddleware(MiddlewareDelegate<TestContext> next, string message)
        {
            _next = next;
            _message = message;
        }

        public Task InvokeAsync(TestContext context)
        {

            context.Message.AppendLine(_message);
            _next(context);
            return Task.CompletedTask;
        }
    }
}
