using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using CSharpEducation.GroupProject.ChatMSG.Core.Services;
using CSharpEducation.GroupProject.ChatMSG.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace CSharpEducation.GroupProject.ChatMSG.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ChatsController : Controller
  {
    private IChatService chatService;
    private IMessageService messageService;
    //private IInvitationService invitation;

    [HttpGet]
    public async Task<ActionResult<List<ChatResponse>>> GetAll()
    {
      var chats = await chatService.GetAll();
      var response = chats.Select(c => new ChatResponse(c.Id, c.Name, c.Link));
      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Create([FromBody] ChatRequest chatRequest)
    {
      
			Chat newChat = new Chat() {Id =chatRequest.Id, Name  = chatRequest.Name};

      //await chatService.CreateChat(newChat);

			string connectionString =
		 "Host=localhost;Port=1234;Username=postgres;Password=123;Database=messengerdb";
		

      
      string sql = @"
            INSERT INTO chat (id, chatname, link)
            VALUES (@id, @chatname, @link);
        ";

        // Данные для добавления нового чата
        int id = chatRequest.Id; 
        string chatname = chatRequest.Name;
        string link ="40";



			using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
      {
       connection.Open();

        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
        {
          command.Parameters.AddWithValue("@id", id);
          command.Parameters.AddWithValue("@chatname", chatname);
          command.Parameters.AddWithValue("@link", link);

				  command.ExecuteReader();
					Console.WriteLine("Новый чат добавлен успешно.");
				
				}

        connection.Close();

      }
			return Ok(newChat);
    }

    public ChatsController(IChatService service, IMessageService messageService)
    {
      chatService = service;
      this.messageService = messageService;
    
    }
  }
}
