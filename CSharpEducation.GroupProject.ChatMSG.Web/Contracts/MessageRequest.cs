namespace CSharpEducation.GroupProject.ChatMSG.Web.Contracts
{
  public record class MessageRequest(string Content , DateTime DateTime, int ChatId);
}
