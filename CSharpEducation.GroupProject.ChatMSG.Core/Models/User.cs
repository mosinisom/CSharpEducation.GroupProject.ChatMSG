using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Models
{
  public class User 
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
