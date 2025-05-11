using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Main
{
    public class FailoverRouteOptions
    {
        public string PrimaryPath { get; set; } = "/main-service";
        public string FallbackPath { get; set; } = "/backup-service";
    }

    public static class FailoverRouteMiddlewareExtensions
    {
        public static IApplicationBuilder UseFailoverRoute(this IApplicationBuilder app, Action<FailoverRouteOptions> configureOptions)
        {
            var options = new FailoverRouteOptions();
            configureOptions(options);
            return app.UseMiddleware<FailoverRouteMiddleware>(options);
        }
    }

}
