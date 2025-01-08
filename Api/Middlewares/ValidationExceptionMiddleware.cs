using System.Text.Json;
using Api.Dtos;
using FluentValidation;

namespace Api.Middlewares
{
  public class ValidationExceptionMiddleware
  {
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (ValidationException ex)
      {
        context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var response = WsResponse<object>.BuildBadResponse(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList());

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
      }
    }
  }
}