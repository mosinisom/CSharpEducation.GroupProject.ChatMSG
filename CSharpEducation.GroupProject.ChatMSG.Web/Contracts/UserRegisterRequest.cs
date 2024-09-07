namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public class UserRegisterRequest
  {
    public required string UserName { get; init; }
    public required string Password { get; init; }
  }
}
