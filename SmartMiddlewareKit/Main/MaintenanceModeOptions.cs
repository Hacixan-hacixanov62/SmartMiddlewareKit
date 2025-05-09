using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.Middlewares;


namespace SmartMiddlewareKit.Main
{
    public class MaintenanceModeOptions
    {
        public bool IsMaintenanceMode { get; set; }
        public string Message { get; set; } = "We are currently in maintenance mode.";
    }

    public static class MaintenanceModeMiddlewareExtensions
    {
        public static IApplicationBuilder UseMaintenanceMode(this IApplicationBuilder app, MaintenanceModeOptions options)
        {
            return app.UseMiddleware<MaintenanceModeMiddleware>(options);
        }
    }
}
