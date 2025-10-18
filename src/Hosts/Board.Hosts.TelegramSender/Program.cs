using Board.Domain.RabbitMQMessages;
using MassTransit;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("user-created-event", e =>
    {
        e.Consumer<UserCreatedConsumer>();
    });
});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Consumer TelegramSender started");
    Console.WriteLine("Press enter to exit");

    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}

public class UserCreatedConsumer() : IConsumer<UserCreated>
{
    private readonly Bot bot = new();
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        //var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"UserCreated message: {context.Message.Username}");
        await bot.SendMessageToList(context.Message.Username);
        await Task.CompletedTask;
    }
}

public class Bot
{
    private static List<Chat> chats = [];
    private readonly TelegramBotClient bot;

    public Bot()
    {
        bot = new TelegramBotClient("8314937046:AAFgkOZWz1DoVUjDcE4-iYNq8Ut85hjGv6I");
        bot.OnMessage += OnMessage;
    }

    async Task OnMessage(Message msg, UpdateType type)
    {
        if (msg.Text is null) return;
        Console.WriteLine($"Received {type} '{msg.Text}' in {msg.Chat}");
        if (chats.Count() == 0)
        {
            chats.Add(new Chat { Id = msg.Chat.Id, Username = msg.Chat.Username });
        }
        else
        {
            if (chats.FirstOrDefault(x => x.Id == msg.Chat.Id)?.Id != msg.Chat.Id)
            {
                chats.Add(new Chat { Id = msg.Chat.Id, Username = msg.Chat.Username });
            }
        }

        await bot.SendMessage(msg.Chat, $"Вы подписаны на рассылку");
        Console.WriteLine($"Chats count: {chats.Count()}");
    }

    public async Task SendMessageToList(string msg)
    {
        if (chats.Count() == 0) return;
        foreach (var chat in chats)
        {
            await bot.SendMessage(chat, $"Добавлен новый пользователь: {msg}");
        }
    }

}




