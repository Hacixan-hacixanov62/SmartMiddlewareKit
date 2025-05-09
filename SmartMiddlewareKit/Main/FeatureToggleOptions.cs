using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Main
{
    public class FeatureToggleOptions
    {
        public string FeatureName { get; set; }
        public Func<ClaimsPrincipal, bool> EnableFeature { get; set; }
    }

    public static class FeatureToggleMiddlewareExtensions
    {
        public static IApplicationBuilder UseFeatureToggle(this IApplicationBuilder app, Action<FeatureToggleOptions> configureOptions)
        {
            var options = new FeatureToggleOptions();
            configureOptions(options);
            return app.UseMiddleware<FeatureToggleMiddleware>(options);
        }
    }

}
