using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using CSharpEducation.GroupProject.ChatMSG.Core.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Linq;
using System;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Services
{
	public class InvitationService :IInvitationService
	{
		private readonly DataContext _context;

		public string GenerateInvitationLink()
		{
			return Guid.NewGuid().ToString();
		}
		/*public async Task SaveInvitationLink(DataContext context)
		{
			var newLink = GenerateInvitationLink();
			context.Link = newLink;
			context.CreatedAt = DateTime.Now;
			// update chat
		}*/

		public async Task GetInvitationByLink() //принимает чат, создает для него ссылку и возвращает ее
		{
			//SaveInvationLink(chat); 
			//FirstOrDefault(i => i.Link == link && !i.IsUsed);
			//return chat.Link;
		}
		public void AddUserToChat()
		{
			//user from user add chatuser, where chatlink == link
		
		}
		public InvitationService(DataContext context)
		{
			_context = context;
		}
	}
}


