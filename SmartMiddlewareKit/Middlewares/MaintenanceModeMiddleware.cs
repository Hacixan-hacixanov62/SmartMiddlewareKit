using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.Base;
using SmartMiddlewareKit.Main;
using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using SmartMiddlewareKit.MIddleware.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{

    // Bu Middleware vasitesile sen veb-saytin texniki xidmet rejimnde olub olmadigini yoxlaya bilersen 
    // Əgər aktivdirsə, bütün istifadəçilərə cavab olaraq 503 Service Unavailable statusu və xüsusi bir mesaj göndərir.

    //Məsələn, sistemə yenilənmə, məlumat bazası backup, kritik dəyişiklik etdiyin vaxt IsMaintenanceMode = true qoyursan.
    //
    //Bu halda:
    //Bütün istifadəçilər sistemə daxil olmaq istəyərkən 503 status alırlar.
    //Əlavə təhlükəsizlik təmin olunur.
    //Server rahatlıqla texniki işə keçə bilir.


    public class MaintenanceModeMiddleware : IMiddleware<ContextBase>
    {
        private readonly MaintenanceModeOptions _options;

        public MaintenanceModeMiddleware(MaintenanceModeOptions options)
        {
            _options = options;
        }

        public async Task InvokeAsync(ContextBase context, MiddlewareDelegate<ContextBase> next)
        {
            if (_options.IsMaintenanceMode)
            {
                var httpContext = (context as HttpContextWrapper)?.HttpContext;

                if (httpContext != null)
                {
                    httpContext.Response.StatusCode = 503;
                    await httpContext.Response.WriteAsync(_options.Message);
                }
            }
            else
            {
                await next(context);
            }
        }

    }
}
