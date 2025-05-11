using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Main
{
    public class RequestReplayOptions
    {
        public bool EnableReplay { get; set; } = true;  // by default, replay is enabled
        public string LogDirectory { get; set; } = "Logs/Replays";
    }

    public static class RequestReplayMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestReplay(this IApplicationBuilder app, Action<RequestReplayOptions> configureOptions)
        {
            var options = new RequestReplayOptions();
            configureOptions(options);
            return app.UseMiddleware<RequestReplayMiddleware>(options);
        }
    }

}
