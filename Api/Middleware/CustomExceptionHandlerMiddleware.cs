using Application.Common.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Middleware
{
	public class CustomExceptionHandlerMiddleware
	{
		private RequestDelegate next;

		public CustomExceptionHandlerMiddleware(RequestDelegate next) => this.next = next;

		public async Task Invoke(HttpContext context) 
		{
			try
			{
				await next(context);
			}
			catch (Exception ex) 
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex) 
		{
			var code = HttpStatusCode.InternalServerError;
			var result = string.Empty;

			switch (ex) 
			{
				case ValidationException validationEx:
					code = HttpStatusCode.BadRequest;
					result = JsonSerializer.Serialize(validationEx.Errors);
					break;
				case NotFoundException:
					code = HttpStatusCode.NotFound;
					break;
				default:
					code = HttpStatusCode.InternalServerError;
					break;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			if (result == string.Empty)
				result = JsonSerializer.Serialize(new {error = ex.Message});

			return context.Response.WriteAsync(result);
		}
	}
}
