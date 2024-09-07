namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public record class MessageResponse(int Id, string Content, string DateTime, int ChatId, string UserId, string UserName);
}
