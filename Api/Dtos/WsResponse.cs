using Api.Catalogs;

namespace Api.Dtos
{
  public class WsResponse<T>
  {
    public bool Status { get; set; }
    public int StatusCode { get; set; }

    public string? Message { get; set; }
    public T? Data { get; set; }
    public WsResponse(bool status, int statusCode, string? message, T? data)
    {
      Status = status;
      StatusCode = statusCode;
      Message = message;
      Data = data;
    }

    public static WsResponse<T> BuildOkResponse(T data)
    {
      return new WsResponse<T>(true, ResponseCodeCatalogs.Ok, ResponseMessageCatalogs.Ok, data);
    }

    public static WsResponse<string> BuildErrorResponse(string message)
    {
      return new WsResponse<string>(false, ResponseCodeCatalogs.InternalServerError, message, null);
    }

    public static WsResponse<T> BuildBadResponse(T data)
    {
      return new WsResponse<T>(false, ResponseCodeCatalogs.BadRequest, ResponseMessageCatalogs.BadRequest, data);
    }

    public static WsResponse<string> BuildNotFoundResponse(string message)
    {
      return new WsResponse<string>(false, ResponseCodeCatalogs.NotFound, message, null);
    }

    public static WsResponse<string> BuildUnauthorizedResponse()
    {
      return new WsResponse<string>(false, ResponseCodeCatalogs.Unauthorized, ResponseMessageCatalogs.Unauthorized, null);
    }
  }
}