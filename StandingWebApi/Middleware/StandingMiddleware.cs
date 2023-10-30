using Microsoft.Data.SqlClient;
using StandingBackProject.API.Models.OutputModels;
using StandingBackProject.Business.Exceptions;
using System.Net;
using System.Text.Json;

namespace StandingBackProject.API.StandingMiddleware
{
    public class StandingMiddleware
    {
        private readonly RequestDelegate _next;

        public StandingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AuthorizationException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Forbidden, ex.Message);
            }
            catch (AccessViolationException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (SqlException)
            {
                await HandleExceptionAsync(context, HttpStatusCode.ServiceUnavailable, "БД не алё");
            }
            catch (NullReferenceException)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, "Не все данные заполнены");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
        {
            var result = JsonSerializer.Serialize(new ErrorOutputModel
            {
                Message = message,
                StatusCode = (int)code,
                StatusCodeName = code.ToString()
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}

