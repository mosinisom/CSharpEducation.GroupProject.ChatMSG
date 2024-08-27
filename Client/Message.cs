internal sealed class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public DateTime Date { get; set; }

    public Message(int id, string text, string sender, string receiver, DateTime date)
    {
        Id = id;
        Text = text;
        Sender = sender;
        Receiver = receiver;
        Date = date;
    }
}