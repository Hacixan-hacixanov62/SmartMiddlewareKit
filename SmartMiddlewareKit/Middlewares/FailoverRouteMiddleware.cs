using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SmartMiddlewareKit.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{
    public class FailoverRouteMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly FailoverRouteOptions _options;

        public FailoverRouteMiddleware(RequestDelegate next, IOptions<FailoverRouteOptions> options)
        {
            _next = next;
            _options = options.Value; 
        }

    
        public async Task InvokeAsync(HttpContext context)
        {
           
            if (IsPathAvailable(_options.PrimaryPath))
            {
                context.Request.Path = _options.PrimaryPath;
            }
            else if (IsPathAvailable(_options.FallbackPath))
            {
                context.Request.Path = _options.FallbackPath;
            }

            await _next(context);
        }

        private bool IsPathAvailable(string path)
        {
            return !string.IsNullOrEmpty(path) && path.StartsWith("/");
        }
    }
}
