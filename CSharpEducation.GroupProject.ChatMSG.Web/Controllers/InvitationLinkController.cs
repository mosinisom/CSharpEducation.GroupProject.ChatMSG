using CSharpEducation.GroupProject.ChatMSG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.DataBase;
using CSharpEducation.GroupProject.ChatMSG.Web.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;


namespace CSharpEducation.GroupProject.ChatMSG.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvitationController : Controller
	{
		//private IInvitationService invitationService;
		//private Chat chat;

		//[HttpGet("generated-link")]
		[HttpGet("{name}")]
		public async Task<IActionResult> GenerateInvitationLink(string name)
		{
			string connectionString =
			 "Host=localhost;Port=1234;Username=postgres;Password=123;Database=messengerdb";

			string? link;

			string sql= "SELECT link FROM chat WHERE chatname = @chatname";

			string chatname = name ;

			using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
			{
				connection.Open();

				using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@chatname", chatname);

					NpgsqlDataReader reader = command.ExecuteReader();

					reader.Read();
					
					link = reader["link"].ToString();

					Console.WriteLine($"Получена ссылка на чат: {link}");
					reader.Close();
				}
				
				connection.Close();
			}
				return Ok(new { Link = link });
		}

		[HttpGet("process-link/{link}")]
		public async Task<IActionResult> ProcessInvitationLink(string link)
		{
			//var invitation = await invitationService.GetInvitationByLink();
			/*if (invitation == null)
			{
				return NotFound("Invitation not found or already used");
			}*/

			// Логика добавления пользователя в чат
			AddUserToChat();

			// Отметить приглашение как использованное
			//invitation.IsLinkUsed = true;
			//await invitationService.SaveInvitationLink(chat);

			return Ok("Invitation processed successfully");
		}


		private void AddUserToChat()
		{
			
		}

		public InvitationController()
		{
			//this.invitationService = invitationService;
		}
	}
}

