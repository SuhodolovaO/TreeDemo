using Application.Services;
using Domain.Enums;
using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace TreeDemo.Middleware
{
    public class ExceptionLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IEventService eventService)
        {
            try
            {
                await _next(context);
            }
            catch (SecureException se)
            {
                await HandleException(context, eventService, EventTypes.Secure, se.Message);
            }
            catch
            {
                await HandleException(context, eventService, EventTypes.Exception, string.Empty);
            }
        }

        private async Task HandleException(
            HttpContext context, IEventService eventService, EventTypes eventType, string message)
        {
            var errorEventMessage = await eventService.CreateErrorEvent(eventType, message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(context.Response.Body, errorEventMessage);
        }
    }
}
