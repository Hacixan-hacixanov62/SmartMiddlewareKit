using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using SmartMiddlewareKit.MIddleware.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middleware.Test
{
    public class TestMiddlewareBuilder : MiddlewareBuilderBase<TestContext>
    {
        public TestMiddlewareBuilder(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public TestMiddlewareBuilder(MiddlewareBuilderBase<TestContext> builder)
            : base(builder)
        {
        }

        public override IMiddlewareBuilder<TestContext> New()
        {
            return new TestMiddlewareBuilder(this);
        }
    }
}
