using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions
{
    public delegate Task MiddlewareDelegate<TContext>(TContext context)
            where TContext : ContextBase;
}
