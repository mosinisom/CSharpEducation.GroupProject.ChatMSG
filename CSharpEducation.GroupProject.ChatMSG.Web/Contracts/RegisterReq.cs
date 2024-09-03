namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public class RegisterReq
  {
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public required string Email { get; init; }
  }
}
