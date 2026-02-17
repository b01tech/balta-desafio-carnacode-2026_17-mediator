using MediatorChallenge.Chat;

Console.WriteLine("=== Sistema de Chat em Grupo (Mediator) ===");

var room = new ChatRoom();

var alice = new ChatUser("Alice", room);
var bob = new ChatUser("Bob", room);
var carlos = new ChatUser("Carlos", room);
var diana = new ChatUser("Diana", room);

Console.WriteLine("=== Usuários Entrando no Grupo ===");
alice.JoinGroup();
bob.JoinGroup();
carlos.JoinGroup();
diana.JoinGroup();

Console.WriteLine();
Console.WriteLine("=== Conversação ===");
alice.SendMessage("Olá, pessoal!");
bob.SendMessage("Oi, Alice!");
carlos.SendMessage("E aí!");

Console.WriteLine();
Console.WriteLine("=== Mensagem Privada ===");
alice.SendPrivate("Bob", "Bob, você viu o relatório?");

Console.WriteLine();
Console.WriteLine("=== Moderação ===");
alice.RequestMute("Carlos");
carlos.SendMessage("Ainda posso falar?");

Console.WriteLine();
Console.WriteLine("=== Saindo do Grupo ===");
diana.LeaveGroup();
alice.SendMessage("Diana saiu");
