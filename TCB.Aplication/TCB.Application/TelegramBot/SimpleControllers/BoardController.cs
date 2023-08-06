using TCB.Aplication.Domain;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Message = TCB.Aplication.Domain.Message;

namespace TCB.Aplication.TelegramBot.Managers;

public class BoardController:ControllerBase
{
    private readonly BoardService _boardService;

    public BoardController(ITelegramBotClient botClient , BoardService boardService) 
        : base(botClient)
    {
        _boardService = boardService;
    }

  
    
    
    public override void HandleAction(ControllerContext context)
    {
        
        
        switch (context.Session.Action)
        {
            
            case "ListAllBoard":
            {
                ListAllBoard(context);
                break;
            }
            case "CreateBoard":
            {
                CreateBoard(context);
                break;
            }
            case "PrintAllBoards":
            {
                break;
            }
            case "WriteMessageToBoard":
            {
                break;
            }
            case "WriteMessageToBoardIf":
            {
                break;
            }
            case "EnterNickName":
            {
                break;
            }
            case "Back":
            {
                
                break;
            }
            default:
            {
                SendMessage(context, "\\ListAllBoard or \\CreateBoard or \\Back tanlang");
                Start(context);
                break;
            }
                
        }
    }

    
    
    public async Task Start(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            SendMessage(context, "\\ListAllBoard or \\CreateBoard or \\Back tanlang");
        }
        switch (context.Update.Message.Text)
        {
            case "ListAllBoard":
            {
                context.Session.Action = "ListAllBoard";
                break;
            }
            case "CreateBoard":
            {
                context.Session.Action = "CreateBoard";
                break;
            }
            case "Back":
            {
                
                break;
            }
            default:
            {
                
                break;
            }
                
        }   
    }

   
    
    
    public async Task ListAllBoard(ControllerContext context)
    {
        await PrintAllBoards(context, null);
        
    }

   
    
    
    public async Task PrintAllBoards(ControllerContext context ,int? index = 0)
    {
        List<Board> boards =await _boardService.GetAllModel();
        foreach (var board in boards)
        {
            await SendMessage(context, board.NickName);
        }

        await SendMessage(context, "Can you write Board?\n\\Yes  or \\No");

        context.Session.Action = "WriteMessageToBoardIf";
    }




    public async Task EnterNickName(ControllerContext context)
    {
        if (context.Update.Message.Type!=MessageType.Text)
        {
            await SendMessage(context, "Enter your nickname");
            return;
        }

        string nickName = context.Update.Message.Text;
        Board board = await _boardService.FindByNickNameModel(nickName);
        if (board is null)
        {
            await SendMessage(context,"Board Not Found");
            return;
        }

        context.Session.board = board;
        context.Session.Action = "WriteMessageToBoard";

        await SendMessage(context, "write to message");
    }
    
    
    
    public async Task WriteMessageToBoardIf(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            await SendMessage(context, "Place write to Text");
            return;
        }

        if (context.Update.Message.Text == "\\Yes")
        {
            await SendMessage(context, "Enter  nickname");
            context.Session.Action = "EnterNickName";
            return;
        }
        else if(context.Update.Message.Text == "\\No")
        {
            context.Session.Action = "Start";
            return;
        }
        else
        {
            await SendMessage(context, "Can you write Board?\n\\Yes  or \\No");
        }
        
    }



    public async Task WriteMessageToBoard(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            context.Session.Action = "Start";
            return;
        }

        _boardService.WriteMessageToBoard(context.Session.board.Id, new Message()
        {
            BoardId = context.Session.board.Id,
            time = DateTime.Now,
            text = context.Update.Message.Text,
            FromId = context.Update.Message.Chat.Id
        });
        await SendMessage(context, "");
        context.Session.Action = "Start";
        context.Session.board = null;
    }
    
    
    
    
    public async Task CreateBoard(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
        {
            await this.SendMessage(context, "There is an error Enter nickName?\nGo Back >> \\Back");
            return;
        }

        string nickName = context.Update.Message.Text;
        if (nickName == "\\Back")
        {
            context.Session.Action = "Start";
            return;
        }

        if (_boardService.FindByNickNameModel(nickName) is not null)
        {
            await this.SendMessage(context, "This nickName is busy❌\nGo Back >> \\Back");
            return;
        }

        _boardService.CreateBoard(nickName, context.Update.Message.Chat.Id);

        await this.SendMessage(context, "Nickname accepted✅");
        
        context.Session.Action = "Start";
        
    }
    
    
    
}