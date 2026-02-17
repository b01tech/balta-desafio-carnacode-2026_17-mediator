namespace MediatorChallenge.Chat;

public interface IChatMediator
{
    void Join(ChatUser user);
    void Leave(ChatUser user);
    void Broadcast(ChatUser from, string message);
    void SendPrivate(ChatUser from, string toName, string message);
    void Mute(string byName, string targetName);
    void Unmute(string byName, string targetName);
}
