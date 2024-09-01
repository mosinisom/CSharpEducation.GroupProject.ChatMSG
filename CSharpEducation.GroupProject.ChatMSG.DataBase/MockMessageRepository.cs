using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;

namespace CSharpEducation.GroupProject.ChatMSG.DataBase
{
  public class MockMessageRepository : IRepository<MessageEntity>
  {
    private List<MessageEntity> messages = new List<MessageEntity>()
    {
      new MessageEntity() {ChatId = 1, Content = "Привет епта", DateTime = DateTime.Now, User = new User{Name = "Чел1" , } },
      new MessageEntity() {ChatId = 1, Content = "Здарова", DateTime = DateTime.Now, User = new User{Name = "Чел2" } },
      new MessageEntity() {ChatId = 1, Content = "Че дел", DateTime = DateTime.Now, User = new User{Name = "Чел1" } },
      new MessageEntity() {ChatId = 1, Content = "Тебя вертел", DateTime = DateTime.Now, User = new User{Name = "Чел2" } }
    };

    public async Task Add(MessageEntity entity)
    {
      entity.Id = messages.Count();
      messages.Add(entity);
    }

    public async Task<MessageEntity> Get(int id)
    {
      return messages.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IQueryable<MessageEntity>> GetAll(bool includeDeleted = false)
    {
      return messages.Where(x => x.IsDeleted == includeDeleted).AsQueryable();
    }

    public async Task Remove(MessageEntity entity)
    {
      messages.Remove(entity);
    }

    public async Task Update(MessageEntity entity)
    {
      var OldMessage = messages.FirstOrDefault(x => x.Id == entity.Id);
      messages.Remove(OldMessage);
      messages.Add(entity);
    }
    public MockMessageRepository()
    {

    }
  }
}
