using Contracts;
using Entities.Exceptions;
using Entities.Modals;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace UltimateAspNetCore.ServiceExtensions
{
	public static class ExceptionMiddlewareExtensions
	{
		public static void ConfigureExceptionHandler(this WebApplication app,
		ILoggerManager logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						context.Response.StatusCode = contextFeature.Error switch
						{
							NotFoundException => StatusCodes.Status404NotFound,
							_ => StatusCodes.Status500InternalServerError
						};
						logger.LogError($"Something went wrong: {contextFeature.Error}");
						await context.Response.WriteAsync(
						//	new ErrorDetails()
						//{
						//	StatusCode = context.Response.StatusCode,
						//	Message = contextFeature.Error.Message,
						//}.ToString()
						
						new ErrorDetails(context.Response.StatusCode, contextFeature.Error.Message).ToString()
						
						);
					}
				});
			});
			
			app.UseStatusCodePagesWithReExecute("/error/{0}");
		}
		
	}
}
