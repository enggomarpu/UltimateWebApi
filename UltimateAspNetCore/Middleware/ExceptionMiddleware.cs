using Contracts;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Net;
using System.Text.Json;

namespace UltimateAspNetCore.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILoggerManager _logger;
		private readonly IHostEnvironment _env;

		public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger, IHostEnvironment env) {
			_next = next;
			_logger = logger;
			_env = env;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}

			
			catch (NotFoundException ex)
			{

				_logger.LogError($"{ex.Message} \n Exception Error {ex}");
				context.Response.ContentType = "application/json";

				var exceptionStatusCode = (int)HttpStatusCode.InternalServerError;
				
				if (ex.statusCode > 0)
				{
					exceptionStatusCode = ex.statusCode;
				}

				context.Response.StatusCode = exceptionStatusCode;
				var response = new ExceptionDetails(exceptionStatusCode, ex.Message);

				if (_env.IsDevelopment())
				{
					response = new ExceptionDetails(exceptionStatusCode, ex.Message, ex.StackTrace.ToString());
				}

				
				var jsonResponse = JsonSerializer.Serialize(response);

				await context.Response.WriteAsync(jsonResponse);
			}

		}


	}
}
