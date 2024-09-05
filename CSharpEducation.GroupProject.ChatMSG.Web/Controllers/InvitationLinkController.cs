using Microsoft.AspNetCore.Mvc;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Web.Contracts;
using Npgsql;


namespace CSharpEducation.GroupProject.ChatMSG.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvitationController : Controller
	{
		
		private IChatService chatService;

		
		[HttpGet("generated-link/{name}")]
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

		[HttpPut("update-link-by-chatname")]
		public async Task<IActionResult> UpdateLink([FromBody] ChatRequest chatRequest)
		{
			string connectionString =
			 "Host=localhost;Port=1234;Username=postgres;Password=123;Database=messengerdb";

			string newLink = chatService.GenerateInvitationLink() ;

			string sql = "UPDATE chat SET link = @newLink WHERE chatname = @chatname";


			using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
			{
				connection.Open();

				using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@newlink", newLink);
					command.Parameters.AddWithValue("@chatname", chatRequest.Name);

					command.ExecuteReader();

					Console.WriteLine($"Новая ссылка на чат {newLink}");
					
				}

				connection.Close();
			}

			return Ok(new {NewLink = newLink });
		}

		public InvitationController(IChatService chatService)
		{
			this.chatService = chatService;
		}
	}
}

