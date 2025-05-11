using SmartMiddlewareKit.MIddleware.Extensions.Abstractions;
using SmartMiddlewareKit.Middleware.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SmartMiddlewareKit.MIddleware.Extensions.Implementations;

namespace SmartMiddlewareKit.Middleware.Test
{
    public class MiddlewareBuilderTest
    {
        [Fact]
        public async Task InjectToConstructor_Middlewares()
        {
            IServiceProvider provider = new ServiceCollection()
                .BuildServiceProvider();

            IMiddlewareBuilder<TestContext> middlewareBuilder = new TestMiddlewareBuilder(provider);

            var resultBuild = middlewareBuilder
                .UseMiddleware<AddTextMiddleware, TestContext>("Hello")
                .UseMiddleware<AddTextMiddleware, TestContext>("World")
                .Build();

            TestContext context;
            using (var scopedProvider = provider.CreateScope())
            {
                context = new TestContext(scopedProvider.ServiceProvider);
                await resultBuild(context);
            }

            Assert.Equal($"Hello{Environment.NewLine}World{Environment.NewLine}", context.Message.ToString());
        }


        [Fact]
        public async Task InjectToConstructorAndInvoke_Middleware()
        {
            IServiceProvider provider = new ServiceCollection()
                .AddScoped(prov =>
                {
                    return new AddTextFromOptionsMiddlewareOptions()
                    {
                        Text = "World"
                    };
                })
                .BuildServiceProvider();

            IMiddlewareBuilder<TestContext> middlewareBuilder = new TestMiddlewareBuilder(provider);

            var resultBuild = middlewareBuilder
                .UseMiddleware<AddTextFromOptionsMiddleware, TestContext>("Hello")
                .UseMiddleware<AddTextFromOptionsMiddleware, TestContext>("GoodBy")
                .Build();

            TestContext context;
            using (var scopedProvider = provider.CreateScope())
            {
                context = new TestContext(scopedProvider.ServiceProvider);
                await resultBuild(context);
            }

            Assert.Equal($"HelloWorld{Environment.NewLine}GoodByWorld{Environment.NewLine}", context.Message.ToString());
        }
    }
}
