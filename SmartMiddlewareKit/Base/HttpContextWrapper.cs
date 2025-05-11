using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Base
{
    public class HttpContextWrapper : ContextBase
    {
        public HttpContext HttpContext { get; }

        public HttpContextWrapper(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }

        public override IServiceProvider ContextServices => HttpContext.RequestServices;

        public HttpResponse Response => HttpContext.Response;
        public HttpRequest Request => HttpContext.Request;
    }

}
