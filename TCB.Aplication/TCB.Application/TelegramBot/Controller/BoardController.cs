using System.Reflection;
using TCB.Aplication.Domain;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Message = TCB.Aplication.Domain;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

namespace TCB.Aplication.TelegramBot.Managers;

public class BoardController:ControllerBase
{
    private readonly BoardService _boardService;

    public BoardController(ITelegramBotClient botClient,BoardService boardService, ControllerManager controllerManager) : base(botClient, controllerManager)
    {
        _boardService = boardService;
    }

    public override async Task<bool> HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case nameof(CreateBoard):
            {
                await CreateBoard(context);
                return true;
            }
            case nameof(PrintBoard):
            {
                await PrintBoard(context);
                return true;
            }
            case nameof(WriteMessageToBoard):
            {
                await WriteToBoardOrGoBack(context);
                return true;
            }
            case nameof(GetBoardNickName):
            {
                await GetBoardNickName(context);
                return true;
            }
            case nameof(GoBack):
            {
                await GoBack(context);
                return true;
            }
            case nameof(GoHome):
            {
                await GoHome(context);
                return true;
            }
            case nameof(WriteToBoardOrGoBack):
            {
                WriteToBoardOrGoBack(context);
                return true;
            }


        }

        return false;
    }

    public override async Task<bool> HandleUpdate(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
            return false;
        switch (context.Update.Message.Text)
        {
            case "/"+nameof(CreateBoard):
            {
                await CreateBoard(context);
                return true;
            }
            case "/"+nameof(GoHome):
            {
               await GoHome(context);
                return true;
            }
            case "/"+nameof(GoBack):
            {
                await GoBack(context);
                return true;
            }
            case "/"+nameof(PrintBoard):
            {
                await PrintBoard(context);
                return true;
            }
        }

        return false;
    }

    public async Task CreateBoard(ControllerContext context)
    {
        await SendMessage(context, "Enter your Nick Name");
        context.Session.Action = nameof(GetBoardNickName);
    }

    public async Task GoHome(ControllerContext context)
    {
        
    }
   

    public async Task PrintBoard(ControllerContext context)
    {
        List<Board> boards=await _boardService.GetAllModel();
        foreach (var board in boards)
        {
            await SendMessage(context, board.NickName);
        }

        await SendMessage(context, "whether you write on the board or go back \n/Write  /GoBack");
        context.Session.Action = nameof(WriteMessageToBoard);
    }

    public async Task WriteToBoardOrGoBack(ControllerContext context)
    {
        context.Session.BoardSession.NickName = context.Update.Message?.Text;
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await SendMessage(context, "place whether you write on the board or go back \n/Write  /GoBack");
            return;
        }

        switch (context.Update.Message.Text)
        {
            case "/Write":
                await SendMessage(context, "you can write");
                context.Session.Action = nameof(WriteMessageToBoard);
                await WriteMessageToBoard(context);
                return;
            case "/GoBack":
                await GoBack(context);
                break;
        }

        await SendMessage(context, "place whether you write on the board or go back \n/Write  /GoBack");

    }

    public async Task GoBack(ControllerContext context)
    {
        await SendMessage(context, "go back");
        await Start(context);
        context.Session.Action = nameof(Start);
    }
    
    public async Task GetBoardNickName(ControllerContext context)
    {
        context.Session.BoardSession.NickName = context.Update.Message?.Text;
        if (string.IsNullOrEmpty(context.Update.Message?.Text))
        {
            await SendMessage(context, "Place enter  your Nick Name ");
            return;
        }

        Board board =await _boardService.FindByNickName(context.Update.Message.Text);

        if (board is null)
        {
            await SendMessage(context, "nick name busy");
            return;
        }

        await SendMessage(context, "Successful");
        context.Session.BoardSession.BoardId = board.Id;
        context.Session.Action = nameof(Start);

    }
    
    public async Task WriteMessageToBoard(ControllerContext context)
    {
        string? message = context.Update.Message?.Text;

        if (string.IsNullOrEmpty(message))
        {
            await SendMessage(context, "place write text");
            return;
        }
        
        await _boardService.WriteMessageToBoard(context.Session.BoardSession.BoardId,new Message.Message()
        {
            text = message,
            BoardId = context.Session.BoardSession.BoardId,
            FromId = context.Update.Message.Chat.Id,
            messageStatus = MessageStatus.NoRead,
            time = DateTime.Now,
            status = Message.MessageType.Board,
        });

        await SendMessage(context, "successful \nGo Home");

        await Start(context);
    }

    public async Task Start(ControllerContext context)
    {
        await SendMessage(context, "Board Create /CreateBoard\nBoard All List /AllBoard");
    }
    
    
    
}
