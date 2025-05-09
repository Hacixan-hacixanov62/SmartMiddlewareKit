using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Main
{
    public class GeoBlockOptions
    {
        public string[] BlockedCountries { get; set; }
        public string BlockedMessage { get; set; } = "Your country is blocked from accessing this service.";
    }

    public static class GeoBlockMiddlewareExtensions
    {
        public static IApplicationBuilder UseGeoBlock(this IApplicationBuilder app, Action<GeoBlockOptions> configureOptions)
        {
            var options = new GeoBlockOptions();
            configureOptions(options);
            return app.UseMiddleware<GeoBlockMiddleware>(options);
        }
    }
}
