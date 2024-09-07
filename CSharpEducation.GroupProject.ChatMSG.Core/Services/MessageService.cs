using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Services
{
  public class MessageService : IMessageService
  {
    private IRepository<MessageEntity> repository;
    UserManager<UserEntity> userManager;

    public async Task<Message> Add(Message message)
    {
      MessageEntity newMessage = new MessageEntity()
      {
        ChatId = message.ChatId,
        Content = message.Content,
        UserId = message.UserId,
        DateTime = DateTime.Now.ToUniversalTime(),
      };
   
      var messageEntity = await repository.Add(newMessage);
      var user = userManager.Users.Where(u => u.Id == messageEntity.UserId).FirstOrDefault();

      Message createdMessage = new Message()
      {
        Id = messageEntity.Id,
        ChatId = messageEntity.ChatId,
        Content = messageEntity.Content,
        UserId = messageEntity.UserId,
        DateTime = messageEntity.DateTime,
        UserName = user.UserName
      };

      return createdMessage;
    }

    public List<Message> GetAllFromChat(int chatId)
    {       
      var allMessage = repository.GetAll();

      var chatMessages = allMessage.Where(c => c.ChatId == chatId).ToList();

      var userIds = chatMessages.Select(x => x.UserId).Distinct().ToList();

      var chatUsers = userManager.Users.Where(u => userIds.Contains(u.Id)).ToList();

      List<Message> messages = chatMessages.Select(message => new Message()
      {
        ChatId = message.ChatId,
        Content = message.Content,
        DateTime = message.DateTime,
        UserId = message.UserId,
        UserName = chatUsers.Where(u => u.Id == message.UserId).FirstOrDefault().UserName,
      })
        .ToList();

      return messages;
    }

    public MessageService(IRepository<MessageEntity> rep, UserManager<UserEntity> userManager)
    {
      repository = rep;
      this.userManager = userManager;
    }
  }
}
