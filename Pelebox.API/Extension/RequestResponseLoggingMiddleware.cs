using System.Diagnostics;
using System.Text;

namespace Pelebox.API.Extension {
    public class RequestResponseLoggingMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestResponseLoggingMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            // Log request
            var requestBody = await ReadRequestBodyAsync(context.Request);

            _logger.LogInformation(
                "HTTP {Method} {Path} started. Body: {RequestBody}",
                context.Request.Method,
                context.Request.Path,
                requestBody);

            var originalBodyStream = context.Response.Body;

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            var stopwatch = Stopwatch.StartNew();

            try {
                await _next(context);
                stopwatch.Stop();

                // Log response
                var response = await ReadResponseBodyAsync(context.Response);

                _logger.LogInformation(
                    "HTTP {Method} {Path} completed in {ElapsedMs}ms with status {StatusCode}. Response: {Response}",
                    context.Request.Method,
                    context.Request.Path,
                    stopwatch.ElapsedMilliseconds,
                    context.Response.StatusCode,
                    response);

                await responseBody.CopyToAsync(originalBodyStream);
            } catch (Exception ex) {
                stopwatch.Stop();

                _logger.LogError(ex,
                    "HTTP {Method} {Path} failed after {ElapsedMs}ms",
                    context.Request.Method,
                    context.Request.Path,
                    stopwatch.ElapsedMilliseconds);

                throw;
            } finally {
                context.Response.Body = originalBodyStream;
            }
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest request) {
            request.EnableBuffering();

            using var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                leaveOpen: true);

            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;

            return body;
        }

        private async Task<string> ReadResponseBodyAsync(HttpResponse response) {
            response.Body.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(response.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return body;
        }
    }
}