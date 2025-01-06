using Api.Catalogs;

namespace Api.Dtos
{
  public class WsListResponse<T>
  {
    public bool Status { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public int Total { get; set; }
    public List<T?> Data { get; set; }

    public WsListResponse(bool status, int statusCode, string? message, int total, List<T?> data)
    {
      Status = status;
      StatusCode = statusCode;
      Message = message;
      Total = total;
      Data = data;
    }

    public static WsListResponse<T> BuildOkResponse(int total, List<T?> data)
    {
      return new WsListResponse<T>(true, ResponseCodeCatalogs.Ok, ResponseMessageCatalogs.Ok, total, data);
    }
  }
}