using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using CSharpEducation.GroupProject.ChatMSG.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CSharpEducation.GroupProject.ChatMSG.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MessagesController : Controller
  {
    private IMessageService messageService;

    [HttpPost("chats")]
    public async Task<ActionResult<List<MessageResponse>>> GetAllFromChat([FromBody] ChatRequest chat)
    {
      var messages = await messageService.GetAllFromChat(chat.Id);

      var response = messages.Select(msg => new MessageResponse(msg.Id, msg.Content, msg.DateTime, msg.ChatId, msg.UserId, string.Empty));

      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<MessageResponse>> SendMessage([FromBody] MessageRequest msgRequest)
    {
      Message newMessage = new Message()
      {
        ChatId = msgRequest.ChatId,
        Content = msgRequest.Content,
        UserId = msgRequest.UserId,
      };

      await messageService.Add(newMessage);
      return Ok(newMessage);
    }

    public MessagesController(IChatService service, IMessageService messageService)
    {
      this.messageService = messageService;
    }
  }
}
