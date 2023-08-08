

using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;

class Program
{
    
    private static TelegramBotClient _telegramBotClient;
    private static LoginController _loginController;
    private static RegisterController _registerController;
    private static BoardService _boardService;
    private static BoardDataSarvice _boardDataSarvice;
    private static MessageDataServise _messageDataServise;
    private static UserDataService _userDataService;
    private static HomeController _homeController;
    static string com = "Host=localhost; Port=5432; Database=SqlBot; username=postgres; password=Ogabek1407";


    public static void Main(string[] args)
    {
        new TelegramBotStartService().Start().Wait();

        Console.ReadKey();
    }
    
    
    
    
    public static void Main2(string[] args)
    {
        _userDataService = new UserDataService(com);
        _boardService = new BoardService(_boardDataSarvice, _messageDataServise);
       
       
        TelegramBotStartService telegramBotStartService = new TelegramBotStartService();
        telegramBotStartService.Start();
        Console.ReadLine();
    }
    
}








