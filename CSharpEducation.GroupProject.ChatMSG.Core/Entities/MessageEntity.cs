using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Entities
{
  public class MessageEntity : BaseEntity
  {
    public string Content { get; set; }
    public DateTime DateTime { get; set; }
    public int ChatId { get; set; }
    public string UserId { get; set; }
    public UserEntity User { get; set; }
    public ChatEntity Chat { get; set; }
  }
}
