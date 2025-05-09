
using SmartMiddlewareKit.Main;

namespace SmartMiddlewareKit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Maintenance Mode
            app.UseMaintenanceMode(new MaintenanceModeOptions
            {
                IsMaintenanceMode = true,
                Message = "Site is under maintenance. Please try again later."
            });

            // Time Window
            app.UseTimeWindow(options =>
            {
                options.StartHour = 9;
                options.EndHour = 18;
                options.Message = "The service is available between 9 AM and 6 PM.";
            });

            // Geo Block
            app.UseGeoBlock(options =>
            {
                options.BlockedCountries = new[] { "RU", "CN" };
                options.BlockedMessage = "Access is blocked for your country.";
            });

            // Request Replay
            app.UseRequestReplay(options =>
            {
                options.EnableReplay = true;
                options.LogDirectory = "logs/replays"; // absolute path olmamalıdır
            });

            // Failover Route
            app.UseFailoverRoute(options =>
            {
                options.PrimaryPath = "/api/live";
                options.FallbackPath = "/api/backup";
            });

            // Feature Toggle
            app.UseFeatureToggle(options =>
            {
                options.FeatureName = "NewUI";
                options.EnableFeature = user => user.IsInRole("BetaTester");
            });

            // API Endpoints
            app.MapGet("/api/live", async context =>
            {
                await context.Response.WriteAsync("Live API path accessed!");
            });

            app.MapGet("/api/backup", async context =>
            {
                await context.Response.WriteAsync("Backup API path accessed!");
            });

            app.Run();

        }
    }

}

