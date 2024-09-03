namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public record class MessageResponse(int Id, string Content, DateTime DateTime, int ChatId, string UserId, string UserName);
}
