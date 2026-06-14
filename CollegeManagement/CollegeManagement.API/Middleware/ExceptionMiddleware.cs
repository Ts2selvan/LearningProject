using CollegeManagement.API.Common;
using CollegeManagement.API.Model;
using System.Text.Json;

namespace CollegeManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                await HandleException(
                    context,
                    ex.Message,
                    StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                await HandleException(
                    context,
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        private async Task HandleException(
            HttpContext context,
            string message,
            int statusCode)
        {
            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                statusCode;

            var response = new ApiResponse
            {
                Success = false,
                Message = message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
