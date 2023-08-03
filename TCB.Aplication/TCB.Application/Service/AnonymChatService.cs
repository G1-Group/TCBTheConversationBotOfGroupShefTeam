using TCB.Aplication.Domain;
using TCB.Aplication.Service.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.Aplication.Service;

public class AnonymChatService : IAnonymChatService
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly HttpClient httpClient;
    private List<Client> Clients;
    private List<AnonymChat> AnonymChats;
    private string filePAth;

    public AnonymChatService(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
        httpClient = new HttpClient();
        Clients = new List<Client>();
        AnonymChats = new List<AnonymChat>();
    }


    public async Task Initialize()
    {
        _telegramBotClient.StartReceiving(async (client, update, cancellationToken) =>
        {
             var clientOne = Clients.Find(x => x.UserId == update.Message.Chat.Id);
             if (clientOne == null)
             {
                 Clients.Add(new Client()
                 {
                     UserId = update.Message.Chat.Id,
                 });
             }
             
             
             if (update.Message.Type == MessageType.Text)
            {
                if (update.Message.Text == "/start")
                {
                    await HomeConversation(update, cancellationToken);
                }
                if (update.Message.Text == "start conversation✍️")
                {
                    await SendMessage(update.Message.Chat.Id, cancellationToken,
                        "Welcome from anonymous english language  bot");
                     StartConversation(update, cancellationToken).Wait();
                     NewConversation(update, cancellationToken).Wait();
                }
                else if (update.Message.Text == "history✍️")
                {
                    await SendMessage(update.Message.Chat.Id, cancellationToken, "History not ready");
                }
                
                if (update.Message.Text == "next✍️")
                {
                    
                }
                else if (update.Message.Text == "stop✍️")
                {
                    
                }
            }
            else
            {
                Message message = await _telegramBotClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: $"",
                    cancellationToken: cancellationToken);
            }
        }, (client, Exception, cancellationToken) => { });
        
    }

    private async Task NewConversation(Update update, CancellationToken cancellationToken)
    {
        var anonymchat = AnonymChats.Find(x => x.ConnectClientId == update.Message.Chat.Id ||
                                               x.ClientFromId == update.Message.Chat.Id);
        if (anonymchat == null)
        {
            await CreateAnonymChat(update, cancellationToken);
        }
        else
        {
            await SendMessageInAnonymChat(update, cancellationToken, anonymchat);
        }
    }

    private async Task HomeConversation(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "start conversation✍️", "history✍️" },
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode: ParseMode.Html,
            text: "Quydagilardan birini tanlang☺️\n" +
                  "<strong>.StartConversation</strong>\n" +
                  "<strong>.History</strong>\n",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }

    private async Task StartConversation(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "next✍️", "stop✍️" },
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode: ParseMode.Html,
            text: "Agar boshqa conversationga utishni istasangiz yoki tuxtatishni quydagilardan birini tanlang☺️\n" +
                  "<strong>.Next</strong>\n" +
                  "<strong>.Stop</strong>\n",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }


    public async Task SendMessageInAnonymChat(Update update, CancellationToken cancellationToken, AnonymChat anonymChat)
    {
        if (anonymChat.ClientFromId == update.Message.Chat.Id)
        {
            await SendMessage(anonymChat.ConnectClientId, cancellationToken, update.Message.Text);
        }
        else if (anonymChat.ConnectClientId == update.Message.Chat.Id)
        {
            await SendMessage(anonymChat.ClientFromId, cancellationToken, update.Message.Text);
        }
    }

    public async Task SendMessage(ChatId chatId, CancellationToken cancellationToken, string messageFromBot)
    {
        Message message = await _telegramBotClient.SendTextMessageAsync(chatId: chatId,
            text: messageFromBot,
            cancellationToken: cancellationToken);
    }

    public async Task CreateAnonymChat(Update update, CancellationToken cancellationToken)
    {
        AnonymChat anonymChat = null;
        Random rnd = new Random();
        Monitor.Enter(rnd);
        var owneClient = Clients.Find(x => x.TelegramChatId == update.Message.Chat.Id);
        var client = Clients.Find(x =>
            x.TelegramChatId != update.Message.Chat.Id && x.ClientInAnonymChat == false);

        var ownerClientInAnonym = AnonymChats.Find(x => x.ConnectClientId == owneClient.TelegramChatId ||
                                                        x.ClientFromId == owneClient.TelegramChatId);
        var clientInAnonym = AnonymChats.Find(x => x.ConnectClientId == client.TelegramChatId
                                                   || x.ClientFromId == client.TelegramChatId);
        if ((client == null && owneClient == null) && (ownerClientInAnonym == null && clientInAnonym == null))
        {
             SendMessage(update.Message.Chat.Id, cancellationToken,
                "connecting... please after 2 second send any message ").Wait();
        }
        else
        {
            owneClient.ClientInAnonymChat = true;
            client.ClientInAnonymChat = true;

            anonymChat = new AnonymChat()
            {
                CreateData = DateTime.Now,
                Status = AnonymChatStatus.Active,
                ConnectClientId = client.TelegramChatId,
                ClientFromId = owneClient.TelegramChatId
            };
            AnonymChats.Add(anonymChat);
            if (anonymChat != null)
                await SendMessageInAnonymChat(update, cancellationToken, anonymChat);
        }
        Monitor.Exit(rnd);

    }
}