

using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;

class Program
{
    
    private static TelegramBotClient _telegramBotClient;
    private static BoardCreateController _boardCreateCintroller;
    private static BoardListAllBoard _boardListAllBoard;
    private static LoginController _loginController;
    private static RegisterController _registerController;
    private static BoardService _boardService;
    private static BoardDataSarvice _boardDataSarvice;
    private static MessageDataServise _messageDataServise;
    private static UserDataService _userDataService;
    private static HomeController _homeController;
    private static HandleUser _handleUser;
    static string com = "Host=localhost; Port=5432; Database=SqlBot; username=postgres; password=Ogabek1407";


    public static void Main(string[] args)
    {
        _userDataService = new UserDataService(com);
        _boardService = new BoardService(_boardDataSarvice, _messageDataServise);
        _boardCreateCintroller = new BoardCreateController(_telegramBotClient, _boardService);
        _boardListAllBoard = new BoardListAllBoard(_telegramBotClient, _boardService);
        _registerController = new RegisterController(_telegramBotClient,_userDataService);
        _loginController = new LoginController(_telegramBotClient, _userDataService);
        _homeController = new HomeController(_telegramBotClient, _boardCreateCintroller, _boardListAllBoard,
            _loginController, _registerController, _userDataService);
        _handleUser = new HandleUser(_homeController,_userDataService);
        TelegramBotStartService telegramBotStartService = new TelegramBotStartService(_handleUser);
        telegramBotStartService.Start();
        Console.ReadLine();
    }
    
}








