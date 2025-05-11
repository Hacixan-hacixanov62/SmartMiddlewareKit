using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Implementations
{
    public static class RunExtensions
    {
        public static void Run<TContext>(this IMiddlewareBuilder<TContext> app, MiddlewareDelegate<TContext> handler)
            where TContext : ContextBase
        {
            app.Use(_ => handler);
        }
    }
}
