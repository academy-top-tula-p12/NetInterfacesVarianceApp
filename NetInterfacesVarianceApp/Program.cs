//
IMessanger<EmailMessage, Message> messanger = new EmailMessanger();
Message myMessage = messanger.CreateMessage("Hello world");
Console.WriteLine(myMessage.Text);
messanger.SendMessage(new EmailMessage("Hello people!"));

//
IMessanger<EmailMessage, EmailMessage> emailMessanger = new EmailMessanger();
var emaleMessage = emailMessanger.CreateMessage("Hello All!");
emailMessanger.SendMessage(emaleMessage);

//
IMessanger<Message, Message> baseMessanger = new EmailMessanger();
var baseMessage = baseMessanger.CreateMessage("Hello from Tula!");
baseMessanger.SendMessage(baseMessage);

// 


/*
IMessanger<SmsMessage> phone = new EmailMessanger();
phone.Send(new SmsMessage("Hello from Tula!"));

IMessanger<Message> baseMessanger = new EmailMessanger();
IMessanger<SmsMessage> smsMessanger = baseMessanger;
smsMessanger.Send(new SmsMessage("Happy New Year!"));
*/


interface IMessanger<in TI, out TO>
{
    TO CreateMessage(string text);
    void SendMessage(TI message);
}

class EmailMessanger : IMessanger<Message, EmailMessage>
{
    public EmailMessage CreateMessage(string text)
    {
        return new EmailMessage($"Email message: {text}");
    }

    public void SendMessage(Message message)
    {
        Console.WriteLine($"Send message: {message.Text}");
    }
}

/*
interface ISendMessanger<in T>
{
    void Send(T message);
}

class SmsSendMessager : ISendMessanger<Message>
{
    public void Send(Message message)
    {
        Console.WriteLine($"Send message: {message.Text}");
    }
}
*/

class Message
{
    public string Text { set; get; }
    public Message(string text) => Text = text;
}

class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
}

class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
}