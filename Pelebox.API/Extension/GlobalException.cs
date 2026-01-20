using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pelebox.API.Extension {
    public class ExceptionHandlingMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IHostEnvironment environment) {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex) {
            var problemDetails = ex switch {
                NotFoundException notFound => new ProblemDetails {
                    Title = "Resource Not Found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = notFound.Message,
                    Instance = context.Request.Path
                },
                ValidationException validation => new ValidationProblemDetails(
                    validation.Errors) {
                    Title = "Validation Error",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.Request.Path
                },
                BusinessRuleException businessRule => new ProblemDetails {
                    Title = "Business Rule Violation",
                    Status = StatusCodes.Status422UnprocessableEntity,
                    Detail = businessRule.Message,
                    Instance = context.Request.Path,
                    Extensions = { ["ruleCode"] = businessRule.RuleCode }
                },
                _ => new ProblemDetails {
                    Title = "Internal Server Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = _environment.IsDevelopment() ? ex.Message :
                        "An error occurred processing your request",
                    Instance = context.Request.Path
                }
            };

            problemDetails.Extensions["traceId"] = context.TraceIdentifier;

            var logLevel = problemDetails.Status >= 500 ?
                LogLevel.Error : LogLevel.Warning;

            _logger.Log(logLevel, ex,
                "Exception occurred: {ExceptionType} - {Message}",
                ex.GetType().Name, ex.Message);

            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
