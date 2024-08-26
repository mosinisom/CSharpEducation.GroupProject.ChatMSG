namespace CSharpEducation.GroupProject.ChatMSG.Application.Abstractions
{
  public abstract class BaseEntity
  {
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
  }
}
