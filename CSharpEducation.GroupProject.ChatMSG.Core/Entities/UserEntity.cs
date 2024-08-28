using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Entities
{
  public class UserEntity : BaseEntity
  {
    public string Name { get; set; }

    [ForeignKey("UserId")]
    public ICollection<Message> Message { get; }

  }
}
