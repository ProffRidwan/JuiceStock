using System.Net;
using FluentValidation;

namespace JuiceStock.Api.Contracts.Common
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ErrorResponse();

            switch (exception)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Validation failed";
                    response.Errors = validationException.Errors
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    break;

                case InvalidOperationException invalidOp:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = invalidOp.Message;
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An unexpected error occurred";
                    response.Errors = new List<string> { exception.Message };
                    break;
            }

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
