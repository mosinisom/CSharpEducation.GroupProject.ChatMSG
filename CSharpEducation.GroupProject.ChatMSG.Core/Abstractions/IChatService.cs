using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Abstractions
{
  public interface IChatService
  {
    Task<IEnumerable<Chat>> GetAll();
    Task<Chat> GetChat(int id);
    Task CreateChat(Chat chat);
  }
}
