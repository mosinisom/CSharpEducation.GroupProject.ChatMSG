namespace CSharpEducation.GroupProject.ChatMSG.Core.Models
{
  public class Chat
  {
    public int Id { get; set; }
    public string Name { get; set; }
		public string Link { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsLinkUsed { get; set; }
	}
}
