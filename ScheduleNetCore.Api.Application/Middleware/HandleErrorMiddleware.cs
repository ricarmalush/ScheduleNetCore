using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ScheduleNetCore.Api.Application.Middleware
{
    public class HandleErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandleErrorMiddleware> _logger;

        public HandleErrorMiddleware(RequestDelegate next, ILogger<HandleErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<HandleErrorMiddleware> logger)
        {
            object errores = null;
            switch (ex)
            {
                case HandlerException me:
                    logger.LogError(ex, "Manejador Error");
                    errores = me.Errors;
                    context.Response.StatusCode = (int)me.Code;
                    break;
                case Exception e:
                    logger.LogError(ex, "Error de Servidor");
                    errores = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errores != null)
            {
                var resultados = JsonConvert.SerializeObject(new { errores });
                await context.Response.WriteAsync(resultados);
            }

        }
    }
}