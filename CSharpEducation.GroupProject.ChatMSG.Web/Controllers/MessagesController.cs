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
      var userName = User.FindFirstValue(ClaimTypes.Name);

      if (userId == null)
      {
        return Unauthorized();
      }

      var messages = messageService.GetAllFromChat(id);

      var response = messages.Select(msg => new MessageResponse(
        msg.Id,
        msg.Content,
        msg.DateTime.ToString("dd.MM.yy H:mm:ss"),
        msg.ChatId,
        msg.UserId,
        msg.UserName));

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

      var createdMessage = await messageService.Add(newMessage);

      MessageResponse messageResponse = new MessageResponse(
        Id: createdMessage.Id,
        Content: createdMessage.Content,
        DateTime: createdMessage.DateTime.ToString("dd.MM.yy H:mm:ss"),
        ChatId: createdMessage.ChatId,
        UserId: createdMessage.UserId,
        UserName: createdMessage.UserName
      );

      return Ok(messageResponse);
    }

    public MessagesController(IChatService service, IMessageService messageService)
    {
      this.messageService = messageService;
    }
  }
}
