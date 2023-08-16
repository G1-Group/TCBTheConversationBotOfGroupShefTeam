
using TCB.Aplication.Configuration;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Infrastructure.Service.Interface;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot.Context.Extension;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot;

public class TelegramBotStartService
{

    private TelegramBotClient _telegramBotClient;

   
       

    private readonly ControllerManager _controllerManager;
  
    private readonly ManagerSession _sessionManager;

    private readonly UserDataService _userDataService;
    private ClientDataService _clientDataService;
    private MessageDataServise _messageDataServise;
    private BoardDataSarvice _boardDataSarvice;

    private AuthService _authService;
    private BoardService _boardService;
    
    private List<Func<ControllerContext, CancellationToken, Task>> updateHandlers { get; set; }
    

    public TelegramBotStartService()
    {
        //DataServices
        _userDataService = new UserDataService(Settings.dbConnectionString);
        _clientDataService = new ClientDataService(Settings.dbConnectionString);
        _messageDataServise = new MessageDataServise(Settings.dbConnectionString);
        _boardDataSarvice = new BoardDataSarvice(Settings.dbConnectionString);
        //services
        _authService = new AuthService(_clientDataService,_userDataService);
        _boardService = new BoardService(_boardDataSarvice, _messageDataServise);
        
       
        this._telegramBotClient = new TelegramBotClient(Settings.BotToken);
        
        _controllerManager = new ControllerManager(_telegramBotClient, _authService, _boardService);
        
        updateHandlers = new List<Func<ControllerContext, CancellationToken, Task>>();
        
        this._sessionManager = new ManagerSession(this._userDataService);
    }

    public async Task Start()
    {
        
        
        //session handler
        updateHandlers.Add(async (context, token) =>
        {
            if (context.Update?.Message?.Chat.Id is null)
                throw new Exception("Chat id not found to find session");
            
            var session = await _sessionManager.GetSessionByChatId(context.Update.Message.Chat.Id);
            context.Session = session;
        });
        
        //Log handler
        updateHandlers.Add(async (context, token) =>
        {
            Console.WriteLine("Log -> {0} | {1} | {2}", DateTime.Now, context.Session.TelegramChatId, context.Update.Message?.Text ?? context.Update.Message?.Caption);
        });
        //add func in handler
        updateHandlers.Insert(updateHandlers.Count, async (context, token) =>
        {
            await context.Forward(_controllerManager);
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
    
    private async Task OnUpdate(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        ControllerContext context = new ControllerContext()
        {
            Update = update
        };
        
        try
        {
            foreach (var updateHandler in this.updateHandlers)
                await updateHandler(context, token);
        }
        catch (Exception e)
        {
            Console.WriteLine("Handler Error: " + e.Message);
        }
        
    }
    
    private async Task ErrorMessage(ITelegramBotClient telegramBotClient, Exception exception, CancellationToken cancellationToken)
    {
    }
    
    
}