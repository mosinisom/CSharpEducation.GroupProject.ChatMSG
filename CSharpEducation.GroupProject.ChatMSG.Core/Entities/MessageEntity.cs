using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Entities
{
  /// <summary>
  /// Сущность сообщения для работы с репозиторием.
  /// </summary>
  public class MessageEntity : BaseEntity
  {
    /// <summary>
    /// Текст сообщения
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Время и дата отправки сообщения.
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

    public UserEntity User { get; set; }
    public ChatEntity Chat { get; set; }
  }
}
