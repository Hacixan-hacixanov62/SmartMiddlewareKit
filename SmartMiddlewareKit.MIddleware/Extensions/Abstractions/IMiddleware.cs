using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Abstractions
{
    public interface IMiddleware<TContext>
        where TContext : ContextBase
    {
        Task InvokeAsync(TContext context, MiddlewareDelegate<TContext> next);
    }
}
