using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Entities
{
  public class UserEntity : IdentityUser
  { 
    public ICollection<MessageEntity> Messages { get; }
  }
}
