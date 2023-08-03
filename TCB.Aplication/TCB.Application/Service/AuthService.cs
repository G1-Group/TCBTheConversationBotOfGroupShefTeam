using TCB.Aplication.Service.Interface;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.Aplication.Service;

public class AuthService : IAuthService
{
    
    public  string botToken = "6612151166:AAG65IbZu6q0K_RXx_8Vkdczm922RQpuCao";
    private TelegramBotClient _telegramBotClient;

    private List<User> _users;
    public AuthService()
    {
        this._users = new List<User>();
        this._telegramBotClient = new TelegramBotClient(botToken);
    }
    
    
    public async Task StartMenu()
    {
        _telegramBotClient.StartReceiving(
            (client, update, cancellationToken) =>
            {
                client.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "",
                    parseMode: ParseMode.Html
                );

                
                if (update.Message.Text == "/start")
                {
                    LanguageMenu(update, cancellationToken);
                }

                if (update.Message.Text == "Uz🌍" || update.Message.Text == "En🌍" || update.Message.Text == "Ru🌍" ||
                    update.Message.Text == "Kz🌍")
                {
                    RegistrationAndLogin(update, cancellationToken);
                }

                if (update.Message.Text == "Registration✍️")
                {
                    Registration(update, cancellationToken);
                }

                if (update.Message.Text == "Login✍️")
                {
                    Login(update, cancellationToken);
                }
                
                
            },
            (client, exception, cancellationToken) =>
            {
                
            },
            new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            }
        );


        Console.ReadLine();
    }

    public async Task LanguageMenu(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Uz🌍", "Ru🌍" , "En🌍" , "Kz🌍"},
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode:ParseMode.Html,
            text: "Assalomu alekum 😊\n" +
                  "Botga xush kelibsiz🫡\n" +
                  "<strong>Tilni tanlang!</strong>🌍\n", 
                  
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }
    
    
    

    public async Task RegistrationAndLogin(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Registration✍️", "Login✍️" },
        })
        {
            ResizeKeyboard = true
        };
        
        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode:ParseMode.Html,
            text: "Quydagilardan Birini tanlang\n" +
                  "<strong>.Registration</strong>\n" +
                  "<strong>.Login</strong>\n",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }

    public async Task Registration(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Phone✍️", "NickName✍️" , "Password✍️"},
        })
        {
            ResizeKeyboard = true
        };
        
        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode:ParseMode.Html,
            text: "<strong>Registration qiling</strong>👇",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }

    public async Task Login(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Password✍️"},
        })
        {
            ResizeKeyboard = true
        };
        
        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode:ParseMode.Html,
            text: "<strong>Login qiling</strong>👇",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }


    public async Task Phone(Update update, CancellationToken cancellationToken)
    {
        Message sentMessage = await _telegramBotClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode:ParseMode.Html,
            text: "Phone number kirting ",
            cancellationToken: cancellationToken);

        Console.WriteLine(update.Message.Text);
        
        
    }

    public Task FindUserFromSql(long userId)
    {
        throw new NotImplementedException();
    }
}