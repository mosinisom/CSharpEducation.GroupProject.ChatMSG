using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;

namespace CSharpEducation.GroupProject.ChatMSG.DataBase
{
  public class MockChatRepository : IRepository<ChatEntity>
  {
    static List<ChatEntity> _chatEntities = new List<ChatEntity>()
    {
      new ChatEntity{Name = "1 чат", Id = 1},
      new ChatEntity{Name = "2 чат", Id = 2},
      new ChatEntity{Name = "3 чат", Id = 3},
      new ChatEntity{Name = "4 чат", Id = 4},
      new ChatEntity{Name = "5 чат", Id = 5},
      new ChatEntity{Name = "6 чат", Id = 6},
      new ChatEntity{Name = "7 чат", Id = 7},
      new ChatEntity{Name = "8 чат", Id = 8},
      new ChatEntity{Name = "9 чат", Id = 9}
    };

    public async Task<ChatEntity> Get(int id)
    {
      return _chatEntities.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IQueryable<ChatEntity>> GetAll(bool includeDeleted = false)
    {
      return _chatEntities.Where(x => x.IsDeleted == includeDeleted).AsQueryable();
    }

    public async Task Add(ChatEntity entity)
    {
      //_chatEntities.Capacity = entity.Id;
      _chatEntities.Add(entity);
    }

    public async Task AddLink(ChatEntity entity)
    {

    }

    public async Task Update(ChatEntity entity)
    {
      var oldEntity = _chatEntities.FirstOrDefault(x => x.Id == entity.Id);
      _chatEntities.Remove(oldEntity);
      _chatEntities.Add(entity);
    }

    public async Task Remove(ChatEntity entity)
    {
      _chatEntities.Remove(entity);
    }
    public MockChatRepository()
    {

    }
  }
}
