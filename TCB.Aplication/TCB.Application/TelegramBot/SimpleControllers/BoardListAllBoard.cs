using TCB.Aplication.Services;
using Telegram.Bot;

namespace TCB.Aplication.TelegramBot.Managers;

public class BoardListAllBoard:ControllerBase
{
    private readonly BoardService _boardService;

    public BoardListAllBoard(ITelegramBotClient botClient,BoardService boardService) : base(botClient)
    {
        _boardService = boardService;
    }

    public override void HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case "PrintBoard":
            {
                PrintBoard(context);
                break;
            }
            case "WriteOrGoToHome":
            {
                WriteOrGoToHome(context);
                break;
            }
            case "NickNameBoard":
            {
                NickNameBoard(context);
                break;
            }
            case "Write":
            {
                Write(context);
                break;
            }
            case "GoHome":
            {
                GoHome(context);
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
        // ... Azimjon zem
        context.Session.Action = "PrintBoard";
    }


    public async Task PrintBoard(ControllerContext context)
    {
        // ... Azimjon zem
        context.Session.Action = "WriteOrGoToHome";
    }

    public async Task WriteOrGoToHome(ControllerContext context)
    {
        // ... Azimjon zem
        
        
        // context.Session.Action == yes  NickNameBoard or GoBack
        
    }

    public async Task NickNameBoard(ControllerContext context)
    {
        // .. Aizmjon zem
        context.Session.Action = "Write";
        // context.Session.board= find board Azimjon zem qushing
    }


    public async Task Write(ControllerContext context)
    {
        // ... Azimjon zem

        context.Session.board = null;
        context.Session.Controller = "HomeController";
        context.Session.Action = null;
    }

    public async Task GoHome(ControllerContext context)
    {
        // ... Og'abek
    }
}