using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using CSharpEducation.GroupProject.ChatMSG.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSharpEducation.GroupProject.ChatMSG.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MessagesController : Controller
  {
    private IMessageService messageService;

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<List<MessageResponse>>> GetAllFromChat([FromRoute] int id)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

      if (userId == null)
      {
        return Unauthorized();
      }

      var messages = messageService.GetAllFromChat(id);

      var response = messages.Select(msg => new MessageResponse(msg.Id, msg.Content, msg.DateTime, msg.ChatId, msg.UserId, string.Empty));

      return Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<MessageResponse>> SendMessage([FromBody] MessageRequest msgRequest)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

      if (userId == null)
      {
        return Unauthorized(); 
      }

      Message newMessage = new Message()
      {
        ChatId = msgRequest.ChatId,
        UserId = userId,
        Content = msgRequest.Content,
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
