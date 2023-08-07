using TCB.Aplication.Services;
using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class BoardCreateCintroller:ControllerBase
{
    private readonly BoardService _boardService;

    public BoardCreateCintroller(ITelegramBotClient botClient,BoardService boardService) : base(botClient)
    {
        _boardService = boardService;
    }

    public override void HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case "NickName":
            {
                NickName(context);
                break;
            }
            default:
            {
                Start(context);
                break;
            }
        }
    }

    public async Task Start(ControllerContext context)
    {
        // ... Sobir 
        context.Session.Action = "NickName";
    }


    public async Task NickName(ControllerContext context)
    {
        // ... Sobir
        context.Session.Action = null;
        context.Session.Controller = "HomeController";
    }


    public async Task GoBack(ControllerContext context)
    {
        // Og'abek 
        context.Session.Controller = "HomeController";
        context.Session.Action = null;
    }


}