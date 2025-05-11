using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Abstractions
{
    public interface IMiddlewareBuilder<TContext>
             where TContext : ContextBase
    {
        IServiceProvider ApplicationServices { get; }

        IMiddlewareBuilder<TContext> Use(Func<MiddlewareDelegate<TContext>, MiddlewareDelegate<TContext>> middleware);

        IMiddlewareBuilder<TContext> New();

        MiddlewareDelegate<TContext> Build();
    }
}
