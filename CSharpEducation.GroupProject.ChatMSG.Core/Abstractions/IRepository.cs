namespace CSharpEducation.GroupProject.ChatMSG.Application.Abstractions
{
  public interface IRepository<T> where T : BaseEntity
  {
    Task<T> Get(int id);
    Task<IQueryable<T>> GetAll(bool includeDeleted = false);
    Task Add(T entity);
    Task Update(T entity);


		Task Remove(T entity);
  }
}
