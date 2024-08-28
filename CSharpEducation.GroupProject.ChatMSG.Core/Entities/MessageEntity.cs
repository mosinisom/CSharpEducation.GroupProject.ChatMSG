using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Entities
{
  public class MessageEntity : BaseEntity
  {
    public string Content { get; set; }
    public DateTime DateTime { get; set; }
    public int ChatId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Chat Chat { get; set; }
  }
}
