using TCB.Aplication.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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
        
    }

    public async Task Start(ControllerContext context)
    {
        
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