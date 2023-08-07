using TCB.Aplication.Domain;
using TCB.Aplication.Services;
using Telegram.Bot;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

namespace TCB.Aplication.TelegramBot.Managers;

public class BoardCreateController:ControllerBase
{
    private readonly BoardService _boardService;

    public BoardCreateController(ITelegramBotClient botClient,BoardService boardService) : base(botClient)
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
        SendMessage(context, "Enter Your Nick Name!\n/GoBack");
        context.Session.Action = "NickName";
    }


    public async Task NickName(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            Start(context);
            return;
        }

        if (context.Update.Message.Text == "/GoBack")
        {
            GoBack(context);
            return;
        }

        Board board = await _boardService.FindByNickNameModel(context.Update.Message.Text);
        if (board.NickName is not null)
        {
            SendMessage(context, "This NickName is busy");
            Start(context);
            return;
        }
        _boardService.CreateBoard(board.NickName, context.Session.board.OwnerId);
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