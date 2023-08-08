using System.Reflection;
using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public class BoardController:ControllerBase
{
    public BoardController(ITelegramBotClient botClient, ControllerManager controllerManager) : base(botClient, controllerManager)
    {
    }

    public override async Task HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case nameof(CreateBoard):
            {
                await CreateBoard(context);
                break;
            }
            case nameof(PrintBoard):
            {
                await PrintBoard(context);
                break;
            }
            case nameof(WriteMessageToBoard):
            {
               await WriteToBoardOrGoBack(context);
                break;
            }
            case nameof(GetBoardNickName):
            {
                await GetBoardNickName(context);
                break;
            }
            case nameof(GoBack):
            {
                await GoBack(context);
                break;
            }
            case nameof(GoHome):
            {
               await GoHome(context);
                break;
            }
            case nameof(WriteToBoardOrGoBack):
            {
                WriteToBoardOrGoBack(context);
                break;
            }
           

        }   
    }

    public override async Task<bool> HandleUpdate(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
            return false;
        switch (context.Update.Message.Text)
        {
            case nameof(CreateBoard):
            {
                await CreateBoard(context);
                return true;
            }
            case nameof(GoHome):
            {
               await GoHome(context);
                return true;
            }
            case nameof(GoBack):
            {
                await GoBack(context);
                return true;
            }
            case nameof(PrintBoard):
            {
                await PrintBoard(context);
                return true;
            }
        }

        return false;
    }

    public async Task CreateBoard(ControllerContext context)
    {


        context.Session.Action = null;
    }

    public async Task GoHome(ControllerContext context)
    {
        
    }
   

    public async Task PrintBoard(ControllerContext context)
    {
        
    }

    public async Task WriteToBoardOrGoBack(ControllerContext context)
    {
           
    }

    public async Task GoBack(ControllerContext context)
    {
        
    }
    
    public async Task GetBoardNickName(ControllerContext context)
    {
        
    }
    
    public async Task WriteMessageToBoard(ControllerContext context)
    {
        
    }
    
    
    
}
