using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using User = TCB.Aplication.Domain.User;

namespace TCB.Aplication.TelegramBot.Managers;

public class RegisterController : ControllerBase
{
    private readonly ITelegramBotClient _botClient;
    private readonly UserDataService _userDataService;


    public RegisterController(ITelegramBotClient botClient,
        UserDataService userDataService) : base(botClient)
    {
        _botClient = botClient;
        _userDataService = userDataService;
    }

    public async  Task Start(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            this.SendMessage(context, "Please select one below");
            return;
        }
        switch (context.Update.Message.Text)
        {
            case "login":
            {
                context.Session.Action = "StartLogin";
                this.SendMessage(context, "Enter password");
                break;
            }
            
        }
    }

    private async Task StartLogin(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            
            return;
        }

        User user = await _userDataService.FindByUserId(context.Update.Message.Chat.Id);

    }

    private async Task ChekUserInDataBase(ControllerContext context)
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