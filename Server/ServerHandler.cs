using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class ServerHandler
{
  private readonly List<Message> _messages = new List<Message>();

  public async Task Send(HttpContext context)
  {
    using var reader = new StreamReader(context.Request.Body);
    var rawMessage = await reader.ReadToEndAsync();
    var message = JsonSerializer.Deserialize<Message>(rawMessage);

    _messages.Add(message);
    await context.Response.WriteAsync("Сообщение получено");
  }

  public async Task Receive(HttpContext context)
  {
    var json = JsonSerializer.Serialize(_messages);
    await context.Response.WriteAsync(json);
  }
}