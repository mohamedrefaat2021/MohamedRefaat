using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MohamedRefaat.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MohamedRefaat.Application.Middlewares
{
  public  class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
                var response = context.Response;
                response.ContentType = "application/json";
                 
                var responseModel = ServiceResponse<string>.Fail(ex.Message.Replace("See the inner exception for details.","") +" _ "+ ex.InnerException?.Message);
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }


    }



}













 