using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Entities
{
  public class ChatEntity : BaseEntity
  {
    public string Name { get; set; }
    public ICollection<MessageEntity> Messages { get; set; } 
  }
}
