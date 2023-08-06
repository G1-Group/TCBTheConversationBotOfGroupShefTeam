using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TCB.Aplication.TelegramBot.Managers;

public class RegisterController : ControllerBase
{
    private readonly ITelegramBotClient _botClient;
    private readonly AnonymChatService _anonymChatService;

    public RegisterController(ITelegramBotClient botClient,
        AnonymChatService anonymChatService) : base(botClient)
    {
        _botClient = botClient;
        _anonymChatService = anonymChatService;
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
                    if (await ChekUserInDataBase(update, cancellationToken))
                    {
                        
                    }
                }
                else if(update.Message.Text == "Login✍️")
                {
                    
                }
            }
        },(client, Exception, cancellationToken)=>
        {
            
        });
    }

    private async Task ChekUserInDataBase(Update update, CancellationToken cancellationToken)
    {
        
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