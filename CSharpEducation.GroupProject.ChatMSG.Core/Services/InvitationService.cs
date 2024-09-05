using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Services
{
	public class InvitationService :IInvitationService
	{
		private IRepository<ChatEntity> chatRepository;
		public string GenerateInvitationLink()
		{
			return Guid.NewGuid().ToString();
		}
		
		public InvitationService (IRepository<ChatEntity> repository)
		{
			chatRepository = repository;
		}
	}
}


