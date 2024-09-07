namespace CSharpEducation.GroupProject.ChatMSG.Application.Abstractions
{
  /// <summary>
  /// Общий репозиторий для управления сущностями.
  /// </summary>
  /// <typeparam name="T">Тип сущности, наследуемой от <see cref="BaseEntity"/>.</typeparam>
  public interface IRepository<T> where T : BaseEntity
  {
    /// <summary>
    /// Получить сущность по ее Id.
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns></returns>
    Task<T> Get(int id);

    /// <summary>
    /// Получение всех сущностей, с возможностью получения удаленных
    /// </summary>
    /// <param name="includeDeleted"> Если true, включает удаленные сущности.</param>
    /// <returns></returns>
    IQueryable<T> GetAll(bool includeDeleted = false);

    /// <summary>
    /// Добавляет новую сущность в репозиторий
    /// </summary>
    /// <param name="entity">Сущность для добавления</param>
    /// <returns></returns>
    Task<T> Add(T entity);

    /// <summary>
    /// Обновляет существующую сущность в репозитории.
    /// </summary>
    /// <param name="entity">Сущность для изменения.</param>
    /// <returns></returns>
    Task Update(T entity);

    /// <summary>
    /// Удаляет существующую сущность из репозитория.
    /// </summary>
    /// <param name="entity">Сущность для удаления</param>
    /// <returns></returns>
    Task Remove(T entity);
  }
}
