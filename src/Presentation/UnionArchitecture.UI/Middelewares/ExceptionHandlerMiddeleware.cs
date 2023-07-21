using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using UnionArchitecture.Aplication.DTOs.ResponseDTOs;
using UnionArchitecture.Persistence.Exceptions;

namespace UnionArchitecture.UI.Middelewares;

public static class ExceptionHandlerMiddeleware
{
	public static IApplicationBuilder UserCustomExceptionHandler(this IApplicationBuilder app)
	{
		app.UseExceptionHandler(errorApp =>
		{
			errorApp.Run(async context =>
			{
				var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
				int StatusCode = (int)HttpStatusCode.InternalServerError;
				string message = "Internal Server Error";

				if (contextFeature is not null)
				{
					if (contextFeature.Error is IBaseException)
					{
						var exception = (IBaseException)contextFeature.Error;
						StatusCode = exception.StatusCode;
						message = exception.CustomMessage;
					}
				}
				context.Response.StatusCode = StatusCode;
				await context.Response.WriteAsJsonAsync(new ExceptionResponseDTO(StatusCode,message));
			});
		});
		return app;
	}
}
