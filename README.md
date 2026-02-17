![CO-5](https://github.com/user-attachments/assets/3b37a043-982a-445d-9611-142ba1a9178b)

## 🥁 CarnaCode 2026 - Desafio 17 - Mediator

Oi, eu sou o Bruno e este é o espaço onde compartilho minha jornada de aprendizado durante o desafio **CarnaCode 2026**, realizado pelo [balta.io](https://balta.io). 👻

Aqui você vai encontrar projetos, exercícios e códigos que estou desenvolvendo durante o desafio. O objetivo é colocar a mão na massa, testar ideias e registrar minha evolução no mundo da tecnologia.

### Sobre este desafio

No desafio **Mediator** eu tive que resolver um problema real implementando o **Design Pattern** em questão.
Neste processo eu aprendi:

- ✅ Boas Práticas de Software
- ✅ Código Limpo
- ✅ SOLID
- ✅ Design Patterns (Padrões de Projeto)

## Problema

Um aplicativo de mensagens tem usuários que precisam enviar mensagens para grupos, notificar quando entram/saem, e gerenciar permissões.
O código atual faz cada usuário conhecer e se comunicar diretamente com todos os outros, criando acoplamento complexo.

## Solução

Implementei o padrão **Mediator** para gerenciar as interações entre os usuários do chat, permitindo que mensagens sejam enviadas para todos os membros do grupo.

Componentes principais:

- Mediador: `ChatRoom.cs`
- Usuário: `ChatUser.cs`
- Contrato: `IChatMediator.cs`

O mediador é responsável por:

- Gerenciar entradas e saídas do grupo, notificando os demais membros.
- Entregar mensagens em broadcast para todos, exceto o remetente.
- Roteamento de mensagens privadas.
- Moderação centralizada (mute/unmute), impedindo envio de quem está mutado.

### Exemplo:

```csharp
var room = new ChatRoom();

var alice = new ChatUser("Alice", room);
var bob = new ChatUser("Bob", room);
var carlos = new ChatUser("Carlos", room);
var diana = new ChatUser("Diana", room);

alice.JoinGroup();
bob.JoinGroup();
carlos.JoinGroup();
diana.JoinGroup();

alice.SendMessage("Olá, pessoal!");
bob.SendMessage("Oi, Alice!");
carlos.SendMessage("E aí!");

alice.SendPrivate("Bob", "Bob, você viu o relatório?");

alice.RequestMute("Carlos");
carlos.SendMessage("Ainda posso falar?");

diana.LeaveGroup();
alice.SendMessage("Diana saiu");
```

Como executar:

```bash
cd src/MediatorChallenge
dotnet build
dotnet run
```

## Sobre o CarnaCode 2026

O desafio **CarnaCode 2026** consiste em implementar todos os 23 padrões de projeto (Design Patterns) em cenários reais. Durante os 23 desafios desta jornada, os participantes são submetidos ao aprendizado e prática na idetinficação de códigos não escaláveis e na solução de problemas utilizando padrões de mercado.

### eBook - Fundamentos dos Design Patterns

Minha principal fonte de conhecimento durante o desafio foi o eBook gratuito [Fundamentos dos Design Patterns](https://lp.balta.io/ebook-fundamentos-design-patterns).

### Veja meu progresso no desafio

[Repositório Central do Desafio](https://github.com/b01tech/desafio-carnacode-2026-design-patterns.git)
