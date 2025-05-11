using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middleware.Test
{
    public class TestContext : ContextBase
    {
        public TestContext(IServiceProvider contextServices)
        {
            ContextServices = contextServices;
        }

        public StringBuilder Message { get; } = new StringBuilder();

        public override IServiceProvider ContextServices { get; }

    }
}
