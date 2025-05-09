using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Main
{
    public class TimeWindowOptions
    {
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public string Message { get; set; } = "Service is available during specified time window.";
    }

    public static class TimeWindowMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeWindow(this IApplicationBuilder app, Action<TimeWindowOptions> configureOptions)
        {
            var options = new TimeWindowOptions();
            configureOptions(options);
            return app.UseMiddleware<TimeWindowMiddleware>(options);
        }
    }
}
