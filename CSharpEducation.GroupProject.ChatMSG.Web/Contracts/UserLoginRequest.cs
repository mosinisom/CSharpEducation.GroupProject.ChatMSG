namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public sealed class UserLoginRequest
  {
    public required string UserName { get; init; }

    public required string Password { get; init; }
  }
}
