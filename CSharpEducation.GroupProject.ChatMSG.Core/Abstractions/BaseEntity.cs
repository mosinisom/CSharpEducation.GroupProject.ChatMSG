namespace CSharpEducation.GroupProject.ChatMSG.Application.Abstractions
{
  /// <summary>
  /// Базовая сущность
  /// </summary>
  public abstract class BaseEntity
  {
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Определяет, была ли сущность удалена. 
    /// Значение true означает, что сущность помечена как удаленная, но может быть сохранена в базе данных.
    /// </summary>
    public bool IsDeleted { get; set; }
  }
}
