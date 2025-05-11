using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Abstractions
{
    public abstract class ContextBase
    {
        public abstract IServiceProvider ContextServices { get; }

        public Exception Error { get; internal set; }
    }
}
