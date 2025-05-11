using Microsoft.AspNetCore.Builder;
using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
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

    //public static class MaintenanceModeMiddlewareExtensions
    //{
    //    public static MiddlewareBuilder<ContextBase> UseMaintenanceMode(this MiddlewareBuilder<ContextBase> builder, MaintenanceModeOptions options)
    //    {
    //        return builder.UseMiddleware<MaintenanceModeMiddleware>(provider =>
    //        {
    //            return new MaintenanceModeMiddleware(options);
    //        });
    //    }
    //}


}
