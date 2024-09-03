﻿using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using CSharpEducation.GroupProject.ChatMSG.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CSharpEducation.GroupProject.ChatMSG.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ChatsController : Controller
  {
    private IChatService chatService;

    [HttpGet]
    public async Task<ActionResult<List<ChatResponse>>> GetAll()
    {
      var chats = await chatService.GetAll();
      var response = chats.Select(c => new ChatResponse(c.Id, c.Name));
      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Create([FromBody] ChatRequest chatRequest)
    {
      Chat newChat = new Chat() { Name  = chatRequest.Name };
      await chatService.CreateChat(newChat);
      return Ok(newChat);
    }
    //добавить контр возвращения чата со всеми сообщениями
    public ChatsController(IChatService service, IMessageService messageService)
    {
      chatService = service;
    }
  }
}
