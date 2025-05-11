using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{                                           //TimeWindowMiddleware saytının yalnız müəyyən saatlarda aktiv olması üçün istifadə olunur.
                                            //Yeni sistem 09:00–18:00 arası işləyəcək, digər saatlarda isə istifadəçiyə xidmətin qapalı olduğunu bildirəcək.
                                            // Bu Middleware vasitesile istifadeci sehifeye yalniz teyin olunmus vaxt erzinde giris ede biler.
    public class TimeWindowMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TimeWindowOptions _options;

        public TimeWindowMiddleware(RequestDelegate next, TimeWindowOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var currentHour = DateTime.Now.Hour;

            if (currentHour >= _options.StartHour && currentHour < _options.EndHour)
            {
                // Saat uyğun gəlir – davam et
                await _next(context);
            }
            else
            {
                // Saat uyğun deyil – mesaj göstər
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(_options.Message);
            }
        }
    }
}
