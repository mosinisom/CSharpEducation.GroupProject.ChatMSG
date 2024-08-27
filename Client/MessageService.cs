using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class MessageService
{
  private readonly HttpClient _client;
  private readonly string _serverUrl;
  private readonly string _clientName;

  public MessageService(string serverUrl, string clientName)
  {
    _client = new HttpClient();
    _serverUrl = serverUrl;
    _clientName = clientName;
  }

  public async Task SendMessageAsync()
  {
    var text = Util.GetMessage();

    var message = JsonSerializer.Serialize(new Message(0, text, _clientName, "всех", DateTime.Now));
    var content = new StringContent(message, Encoding.UTF8, "application/json");
    var response = await _client.PostAsync($"{_serverUrl}/send", content);
    var responseContent = await response.Content.ReadAsStringAsync();
    Console.OutputEncoding = Encoding.UTF8;
    Console.WriteLine(responseContent);
  }

  public async Task ReceiveMessagesAsync()
  {
    var response = await _client.GetAsync($"{_serverUrl}/receive");

    var messages = await JsonSerializer.DeserializeAsync<List<Message>>(await response.Content.ReadAsStreamAsync());
    foreach (var message in messages)
    {
      Util.PrintMessage($"От: {message.Sender}, Для: {message.Receiver}, Дата: {message.Date}, Текст: {message.Text}");
    }
  }
}