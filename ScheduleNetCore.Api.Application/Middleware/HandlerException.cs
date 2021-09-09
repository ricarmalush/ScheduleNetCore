using System;
using System.Net;

namespace ScheduleNetCore.Api.Application.Middleware
{
    //Método que va a controlar nuestros errores.
    public class HandlerException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public object Errors { get; set; }

        public HandlerException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }

    }
}
