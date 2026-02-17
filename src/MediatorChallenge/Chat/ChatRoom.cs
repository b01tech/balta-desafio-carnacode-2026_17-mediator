namespace MediatorChallenge.Chat;

using System;
using System.Collections.Generic;
using System.Linq;

public class ChatRoom : IChatMediator
{
    private readonly Dictionary<string, ChatUser> _users = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _muted = new(StringComparer.OrdinalIgnoreCase);

    public void Join(ChatUser user)
    {
        _users[user.Name] = user;
        foreach (var u in _users.Values.Where(u => u != user))
        {
            u.ReceiveNotification($"{user.Name} entrou no grupo");
        }
    }

    public void Leave(ChatUser user)
    {
        if (_users.Remove(user.Name))
        {
            foreach (var u in _users.Values)
            {
                u.ReceiveNotification($"{user.Name} saiu do grupo");
            }
        }
        _muted.Remove(user.Name);
    }

    public void Broadcast(ChatUser from, string message)
    {
        if (!_users.ContainsKey(from.Name)) return;
        if (_muted.Contains(from.Name))
        {
            from.ReceiveNotification("Você está mutado");
            return;
        }
        foreach (var u in _users.Values.Where(u => u != from && !_muted.Contains(u.Name)))
        {
            u.ReceiveMessage(from.Name, message);
        }
    }

    public void SendPrivate(ChatUser from, string toName, string message)
    {
        if (_muted.Contains(from.Name))
        {
            from.ReceiveNotification("Você está mutado");
            return;
        }
        if (_users.TryGetValue(toName, out var to))
        {
            if (!_muted.Contains(to.Name))
            {
                to.ReceivePrivateMessage(from.Name, message);
            }
        }
    }

    public void Mute(string byName, string targetName)
    {
        if (_users.ContainsKey(targetName))
        {
            _muted.Add(targetName);
            foreach (var u in _users.Values.Where(u => u.Name != byName && u.Name != targetName))
            {
                u.ReceiveNotification($"{targetName} foi mutado por {byName}");
            }
        }
    }

    public void Unmute(string byName, string targetName)
    {
        _muted.Remove(targetName);
    }
}

