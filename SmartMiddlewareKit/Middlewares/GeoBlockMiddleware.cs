using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{                                                // Bu Middleware mueyyen olkelerden gelen sexslerin vəzifə, təhlükəsizlik və ya hüquqi səbəblərlə bloklanması üçün istifadə olunur.
                                                 // Burada daxil etdiyim  müəyyən ölkələrə açıqdır
    public class GeoBlockMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly GeoBlockOptions _options;

        public GeoBlockMiddleware(RequestDelegate next, GeoBlockOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();

            // IP yoxdursa keç
            if (string.IsNullOrEmpty(ipAddress))
            {
                await _next(context);
                return;
            }

            // Real layihədə IP-dən ölkə təyin etmək üçün IP Geolocation servisi istifadə edilməlidir.
            // Məs: MaxMind, IPStack, veya 3rd party API

            string countryCode = await GetCountryFromIP(ipAddress);

            if (_options.BlockedCountries.Contains(countryCode, StringComparer.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(_options.BlockedMessage);
            }
            else
            {
                await _next(context);
            }
        }

        private Task<string> GetCountryFromIP(string ipAddress)
        {
            // Test məqsədi ilə – realda bu IP API ilə əvəz olunmalıdır
            if (ipAddress.StartsWith("5.")) return Task.FromResult("RU");
            if (ipAddress.StartsWith("45.")) return Task.FromResult("CN");
            return Task.FromResult("AZ"); // Default
        }
    }
}
