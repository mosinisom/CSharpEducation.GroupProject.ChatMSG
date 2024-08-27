using System.Text;

public static class Util
{
    public static string GetClientName()
    {
        Console.Write("Введите имя клиента: ");
        return Console.ReadLine();
    }

    public static string GetMessage()
    {
        Console.Write("Введите сообщение: ");
        return Console.ReadLine();
    }

    public static void PrintMessage(string message)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine(message);
    }
}