using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Implementations
{
    internal class MapWhenExceptionOptions<TContext>
          where TContext : ContextBase
    {
        /// <summary>
        /// The branch taken for a positive match.
        /// </summary>
        public MiddlewareDelegate<TContext> Branch { get; set; }
    }
}
