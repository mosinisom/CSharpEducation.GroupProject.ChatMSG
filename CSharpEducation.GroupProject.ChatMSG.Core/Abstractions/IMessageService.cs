using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Abstractions
{
  /// <summary>
  /// Интерфейс сервиса работы с сообщениями
  /// </summary>
  public interface IMessageService
  {
    /// <summary>
    /// Добавляет созданное сообщение
    /// </summary>
    /// <param name="message">Сообщение для добавления</param>
    /// <returns></returns>
    Task<Message> Add(Message message);

    /// <summary>
    /// Получает все сообщения чата по его индентификатору.
    /// </summary>
    /// <param name="chatId">Идентификатор чата.</param>
    /// <returns>Список сообщений чата.</returns>
    List<Message> GetAllFromChat(int chatId);
  }
}
