using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{
    public class FeatureToggleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly FeatureToggleOptions _options;

        public FeatureToggleMiddleware(RequestDelegate next, FeatureToggleOptions options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            ClaimsPrincipal user = context.User;

            // Əgər EnableFeature funksiyası təyin olunubsa və nəticə true-dursa
            if (_options.EnableFeature != null && _options.EnableFeature(user))
            {
                await _next(context);
                return;
            }

            // Əks halda cavab olaraq 403 Forbidden qaytar
            await ReturnFeatureDisabledResponseAsync(context);
        }

        private static async Task ReturnFeatureDisabledResponseAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "text/plain";

            await context.Response.WriteAsync("This feature is disabled for your account.");
        }
    }
}
