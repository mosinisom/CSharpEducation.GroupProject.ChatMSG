using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Abstractions
{
  public interface IMessageService
  {
    Task Add(Message message);
    List<Message> GetAllFromChat(int chatName);
  }
}
