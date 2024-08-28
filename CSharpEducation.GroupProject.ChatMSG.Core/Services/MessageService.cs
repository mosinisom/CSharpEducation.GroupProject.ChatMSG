using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Services
{
  public class MessageService : IMessageService
  {
    private IRepository<MessageEntity> repository;

    public async Task Add(Message message)
    {
      MessageEntity newMessage = new MessageEntity()
      {
        ChatId = message.ChatId,
        Content = message.Content,
        UserId = message.UserId,
        DateTime = DateTime.Now,
      };

      await repository.Add(newMessage);
    }

    public async Task<List<Message>> GetAllFromChat(int chatId)
    {
      var allMessage = await repository.GetAll();
      List<Message> messages = allMessage.Select(message => new Message()
      {
        ChatId = message.ChatId,
        Content = message.Content,
        DateTime = message.DateTime,
        UserId = message.UserId
      })
        .ToList();

      return messages;
    }

    public MessageService(IRepository<MessageEntity> rep)
    {
      repository = rep;
    }
  }
}
