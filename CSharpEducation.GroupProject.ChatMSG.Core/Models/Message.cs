using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Models
{
  /// <summary>
  /// Сущность сообщения для работы с сервисом.
  /// </summary>
  public class Message
  {
    /// <summary>
    /// Идентификатор сообщения.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Текст сообщения.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Время отправки сообщения.
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Идентификатор чата, в котором отправлено сообщение.
    /// </summary>
    public int ChatId { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который отправил сообщение.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Имя пользователя, который отправил сообщение.
    /// </summary>
    public string UserName { get; set; }
  }
}
