using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Marketplace.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController() { }

        public JsonResult GenerateErrorResponse(HttpStatusCode errorType, string message, Exception details = null)
        {
            Response.StatusCode = (int)errorType;
            return new JsonResult(new
            {
                Message = message,
                Details = details
            });
        }

        public JsonResult GenerateInternalErrorResponse(string message, Exception ex = null)
        {
            return GenerateErrorResponse(HttpStatusCode.InternalServerError, message, ex);
        }

        public JsonResult GenerateBadRequestErrorResponse(string message, Exception ex = null)
        {
            return GenerateErrorResponse(HttpStatusCode.BadRequest, message, ex);
        }
    }
}
