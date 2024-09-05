using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System.Runtime.CompilerServices;
using System.Linq;
using System;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Services
{
  public class ChatService : IChatService 
	{
    private IRepository<ChatEntity> chatRepository;
    private InvitationService? invitationService;
    public async Task<IEnumerable<Chat>> GetAll()
    {
      List<Chat> chats = new List<Chat>();
      var entities = await chatRepository.GetAll();
      chats = entities.Select(chat => new Chat { Id = chat.Id, Name = chat.Name }).ToList();

      return chats;
    }

    public async Task<Chat> GetChat(int id)
    {
      ChatEntity chat = await chatRepository.Get(id);
      return new Chat() {Id = chat.Id, Name = chat.Name, Link = chat.Link};
    }

    public async Task CreateChat(Chat chat)
    {
			
			ChatEntity newChat = new ChatEntity() { Name =  chat.Name, Link = chat.Link};
      await chatRepository.Add(newChat);
    }
		public string GenerateInvitationLink()
		{
			return Guid.NewGuid().ToString();
		}
		public ChatService(IRepository<ChatEntity> repository)
		{
			chatRepository = repository;
		}
	}
}


