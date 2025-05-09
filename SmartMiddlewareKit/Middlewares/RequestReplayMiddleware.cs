using Microsoft.AspNetCore.Http;
using SmartMiddlewareKit.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMiddlewareKit.Middlewares
{
    public class RequestReplayMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestReplayOptions _options;

        public RequestReplayMiddleware(RequestDelegate next, RequestReplayOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_options.EnableReplay && context.Request.Method == HttpMethods.Post)
            {
                // Create a copy of the request body
                var bodyStream = new MemoryStream();
                await context.Request.Body.CopyToAsync(bodyStream);
                bodyStream.Seek(0, SeekOrigin.Begin);

                using var reader = new StreamReader(bodyStream, Encoding.UTF8, leaveOpen: true);
                var bodyText = await reader.ReadToEndAsync();

                // Save the body to a file
                var fileName = $"replay_{DateTime.UtcNow:yyyyMMdd_HHmmssfff}.log";
                var filePath = Path.Combine(_options.LogDirectory, fileName);

                Directory.CreateDirectory(_options.LogDirectory);
                await File.WriteAllTextAsync(filePath, bodyText);

                // Rewind the body stream to allow it to be read again by the next middleware
                bodyStream.Seek(0, SeekOrigin.Begin);
                context.Request.Body = bodyStream;
            }

            await _next(context);
        }

    }
}
