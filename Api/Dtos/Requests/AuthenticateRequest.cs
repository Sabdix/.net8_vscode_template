namespace Api.Dtos.Requests
{
  public class AuthenticateRequest
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }
}