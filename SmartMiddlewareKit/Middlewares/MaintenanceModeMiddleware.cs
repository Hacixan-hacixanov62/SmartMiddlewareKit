using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{
    public class MaintenanceModeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MaintenanceModeOptions _options;

        public MaintenanceModeMiddleware(RequestDelegate next, MaintenanceModeOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_options.IsMaintenanceMode)
            {
                context.Response.StatusCode = 503; // Service Unavailable
                await context.Response.WriteAsync(_options.Message);
            }
            else
            {
                await _next(context); // növbəti middleware-ə keç
            }
        }
    }
}
