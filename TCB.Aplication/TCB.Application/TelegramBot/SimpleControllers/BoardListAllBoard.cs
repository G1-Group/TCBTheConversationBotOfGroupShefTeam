using TCB.Aplication.Domain;
using TCB.Aplication.Services;
using Telegram.Bot;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

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
        SendMessage(context, "You See Boards?\n\\Yes or \\No");
        context.Session.Action = "PrintBoard";
    }


    public async Task PrintBoard(ControllerContext context)
    {
        if (context.Update.Message.Text == "\\No")
        {
            GoHome(context);
            return;
        }
        if (context.Update.Message.Text != "\\Yes")
        {
            Start(context);
            return;
        }

        foreach (var board in await _boardService.GetAllModel())
        {
            SendMessage(context, board.NickName);
        }

        SendMessage(context, "Write to board ?\n\\Yes or \\No");
        context.Session.Action = "WriteOrGoToHome";
    }

    public async Task WriteOrGoToHome(ControllerContext context)
    {

        if (context.Update.Message.Text == "\\No")
        {
            GoHome(context);
            return;
        }

        if (context.Update.Message.Text != "\\Yes")
        {
            SendMessage(context, "Write to boar?\n\\Yes or \\No");
            return;
        }
        
        SendMessage(context, "Enter your NickName");
        context.Session.Action = "NickNameBoard";
    }

    public async Task NickNameBoard(ControllerContext context)
    {

        if (context.Update.Message.Type != MessageType.Text)
        {
            SendMessage(context, "Enter your NickName");
            return;
        }
        if (context.Update.Message.Text == "\\GoBack")
        {
            GoHome(context);
            return;
        }
        
        Board board = await _boardService.FindByNickNameModel(context.Update.Message.Text);
        if (board.NickName is null)
        {
            SendMessage(context, "NickName not found\n or \\GoBack");
            return;
        }

        context.Session.board = board;
        SendMessage(context, "Board to Writein");
        context.Session.Action = "Write";
    }


    public async Task Write(ControllerContext context)
    {

        if (context.Update.Message.Type != MessageType.Text)
        {
            GoHome(context);
            return;
        }

        await _boardService.WriteMessageToBoard(context.Session.board.Id,new Message()
       {
           message = context.Update.Message.Text,
           time = DateTime.Now,
           BoardId = context.Session.board.Id,
           FromId = context.Update.Message.Chat.Id,
           status = Domain.MessageType.Board
       });
        
        context.Session.board = null;
        context.Session.Controller = "HomeController";
        context.Session.Action = null;
    }

    public async Task GoHome(ControllerContext context)
    {
        // ... Og'abek
    }
}