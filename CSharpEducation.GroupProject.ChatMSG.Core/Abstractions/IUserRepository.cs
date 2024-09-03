using Microsoft.AspNetCore.Identity;

namespace CSharpEducation.GroupProject.ChatMSG.Application.Abstractions
{
  public interface IUserRepository<T> where T : IdentityUser
  {
    Task<T> Get(int id);
    Task<IQueryable<T>> GetAll(bool includeDeleted = false);
    Task Add(T entity);
    Task Update(T entity);
    Task Remove(T entity);
  }
}
