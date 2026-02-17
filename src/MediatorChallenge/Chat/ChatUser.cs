namespace MediatorChallenge.Chat;

using System;

public class ChatUser
{
    public string Name { get; }
    private readonly IChatMediator _mediator;

    public ChatUser(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void JoinGroup() => _mediator.Join(this);

    public void LeaveGroup() => _mediator.Leave(this);

    public void SendMessage(string message) => _mediator.Broadcast(this, message);

    public void SendPrivate(string toName, string message) =>
        _mediator.SendPrivate(this, toName, message);

    public void RequestMute(string targetName) => _mediator.Mute(Name, targetName);

    public void RequestUnmute(string targetName) => _mediator.Unmute(Name, targetName);

    public void ReceiveMessage(string senderName, string message)
    {
        Console.WriteLine($"  → [{Name}] Recebeu de {senderName}: {message}");
    }

    public void ReceivePrivateMessage(string senderName, string message)
    {
        Console.WriteLine($"  → [{Name}] 🔒 Mensagem privada de {senderName}: {message}");
    }

    public void ReceiveNotification(string notification)
    {
        Console.WriteLine($"  → [{Name}] ℹ️ {notification}");
    }
}
