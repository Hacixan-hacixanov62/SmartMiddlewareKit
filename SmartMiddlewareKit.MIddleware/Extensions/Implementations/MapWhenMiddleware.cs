﻿using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.MIddleware.Extensions.Implementations
{
    internal class MapWhenMiddleware<TContext>
        where TContext : ContextBase
    {
        private readonly MiddlewareDelegate<TContext> _next;
        private readonly MapWhenOptions<TContext> _options;

        /// <summary>
        /// Creates a new instance of <see cref="MapWhenMiddleware"/>.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the request pipeline.</param>
        /// <param name="options">The middleware options.</param>
        public MapWhenMiddleware(MiddlewareDelegate<TContext> next, MapWhenOptions<TContext> options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Executes the middleware.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
        /// <returns>A task that represents the execution of this middleware.</returns>
        public async Task Invoke(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (_options.Predicate(context))
            {
                await _options.Branch(context);
            }
            else
            {
                await _next(context);
            }
        }
    }
}
