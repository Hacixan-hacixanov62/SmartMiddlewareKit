using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Implementations
{
    internal class MapWhenOptions<TContext>
      where TContext : ContextBase
    {
        private Predicate<TContext> _predicate;

        /// <summary>
        /// The user callback that determines if the branch should be taken.
        /// </summary>
        public Predicate<TContext> Predicate
        {
            get
            {
                return _predicate;
            }
            set
            {
                _predicate = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        /// The branch taken for a positive match.
        /// </summary>
        public MiddlewareDelegate<TContext> Branch { get; set; }
    }
}
