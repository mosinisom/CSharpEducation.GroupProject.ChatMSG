using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Models
{
  public class Message
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime DateTime { get; set; }
    public int ChatId { get; set; }
    public int UserId { get; set; }
    public Chat Chat { get; set; }
  }
}
