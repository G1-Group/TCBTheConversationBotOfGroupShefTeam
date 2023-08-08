
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Infrastructure.Service.Interface;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot;

public class TelegramBotStartService
{

    private TelegramBotClient _telegramBotClient;

    private List<Action<ControllerContext>> _handlers =
        new List<Action<ControllerContext>>();

    private readonly ControllerManager _controllerManager;
    private readonly ManagerSession _sessionManager;

    private readonly UserDataService _userDataService;

    private readonly List<string> authRequiredControllers = new List<string>()
    {
        
    };

    public TelegramBotStartService()
    {
        // string botToken = "6271788643:AAE1cjCIemAYlNnVlp6YxczwldYuVj8dGQE";
        this._telegramBotClient = new TelegramBotClient(Settings.BotToken);

        this._userDataService = new UserDataService(Settings.DbConnectionString);
        
        
       // this._controllerManager = new ControllerManager(_telegramBotClient, _userDataService);
        this._sessionManager = new ManagerSession(this._userDataService);
    }

    public async Task Start()
    {
        //Register any handlers
        _handlers.Add(context =>
        {
            Console.WriteLine("{0}| {1}", context.Session.TelegramChatId, context.Update.Message?.Text ?? "No message content.");
        });
        
        //Authorization
        _handlers.Add(context =>
        {
            var controllerName = context.Session.Controller;
            if (this.authRequiredControllers.Find(x => x == controllerName) != null)
            {
                if (context.Session?.User is null)
                    _telegramBotClient.SendTextMessageAsync(context.Update.Message.Chat.Id, "Error: Auth required!").Wait();
            }
        });
        
        
        
        
        
        //Map to controller
        _handlers.Insert(_handlers.Count, (context) =>
        {
            ControllerBase controllerBase = this._controllerManager.GetControllerBySessionData(context.Session);
              controllerBase.Handle(context);
        });
        
        
        
        await StartReceiver();
    }
    
    
    private async Task StartReceiver()
    {
        var cancellationToken = new CancellationToken();
        var options = new ReceiverOptions();
        await _telegramBotClient.ReceiveAsync(((client, update, arg3) => { 
            OnUpdate(client, update, arg3).Wait(arg3);
            return Task.CompletedTask;
        }), ErrorMessage, options, cancellationToken);
    }
    
    private async Task OnUpdate(ITelegramBotClient telegramBotClient, Update update, CancellationToken cancellationToken)
    {
        try
        {
            ControllerContext controllerContext = new ControllerContext()
            {
                Session = await this._sessionManager.GetSessionByChatId(update.Message.Chat.Id),
                Update = update
            };
            foreach (var handler in this._handlers)
                // task
                //     .ContinueWith((prevTask) =>
                //     {
                //         prevTask.Wait(cancellationToken);
                //         handler(controllerContext);
                //     }, cancellationToken, TaskContinuationOptions.OnlyOnRanToCompletion);

                handler(controllerContext);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return;
    }
    
    private async Task ErrorMessage(ITelegramBotClient telegramBotClient, Exception exception, CancellationToken cancellationToken)
    {
    }
    
    
}