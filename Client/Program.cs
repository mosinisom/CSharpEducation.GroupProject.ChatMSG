using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

class Program
{
  static async Task Main(string[] args)
  {
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    var appSettings = configuration.Get<AppSettings>();

    string clientName = Util.GetClientName();

    var messageService = new MessageService(appSettings.ServerUrl, clientName);

    while (true)
    {
      Console.WriteLine("1. Отправить сообщение");
      Console.WriteLine("2. Получить сообщения");
      Console.WriteLine("3. Выйти");
      var choice = Console.ReadLine();

      if (choice == "1")
      {
        await messageService.SendMessageAsync();
      }
      else if (choice == "2")
      {
        await messageService.ReceiveMessagesAsync();
      }
      else if (choice == "3")
      {
        break;
      }
    }
  }
}