namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public record class MessageRequest(int Id , string Content , DateTime DateTime, int ChatId, string UserId);
}
