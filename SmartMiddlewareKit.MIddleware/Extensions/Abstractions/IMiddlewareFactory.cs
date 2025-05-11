using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Abstractions
{
    public interface IMiddlewareFactory<TContext>
        where TContext : ContextBase
    {
        IMiddleware<TContext> Create(Type middlewareType);
        void Release(IMiddleware<TContext> middleware);
    }
}
