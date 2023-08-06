using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.Aplication.TelegramBot.Managers;

public class RegisterController : ControllerBase
{
    private readonly ITelegramBotClient _botClient;

    public RegisterController(ITelegramBotClient botClient) : base(botClient)
    {
        _botClient = botClient;
    }

    public async  Task Initialize()
    {
        _botClient.StartReceiving(async (client, update, cancellationToken) =>
        {
            if (update.Message.Type == MessageType.Text)
            {
                if (update.Message.Text == "/start")
                {
                    GetTokenRegister(update, cancellationToken);
                }
                else if(update.Message.Text == "Registration✍️")
                {
                    
                }
                else if(update.Message.Text == "Login✍️")
                {
                    
                }
            }
        },(client, Exception, cancellationToken)=>
        {
            
        });
    }

    private async Task GetTokenRegister(Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Registration✍️", "Login✍️" },
        })
        {
            ResizeKeyboard = true
        };
        
        Message sentMessage = await _botClient.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            parseMode:ParseMode.Html,
            text: "Please select one below☺️\n" +
                  "<strong>.Registration</strong>\n" +
                  "<strong>.Login</strong>\n",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellationToken);
    }


    public override void HandleAction(ControllerContext context)
    {
        throw new NotImplementedException();
    }
}