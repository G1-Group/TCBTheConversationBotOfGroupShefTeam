using TCB.Aplication.Domain;
using Telegram.Bot.Types;

namespace TCB.Aplication.Service.Interface;

public interface IBoard
{
    
    
    
    /// <summary>
    /// Start Method
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    public Task Start(Update update,CancellationToken cancellationToken);
    
    
    
        
    
    /// <summary>
    /// Create Board Method 
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    public Task CreateBoard(Update update,CancellationToken cancellationToken);
    
    
    
    /// <summary>
    ///  Get Boards from Sql and write to Board
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    public Task ListAllBoard(Update update,CancellationToken cancellationToken);
    
    
    
    
    /// <summary>
    /// Home Go back Method 
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    public Task Back(Update update,CancellationToken cancellationToken);
    
    
    
    
    
    /// <summary>
    /// Send Message to Client
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="text"></param>
    public Task SendMessage(Update update,CancellationToken cancellationToken,string text);

    
    
    /// <summary>
    /// Find Board NickName from Sql 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Task<Board?> FindBoardNickName(string text);
   
    
    
    
    
    /// <summary>
    /// Find Board from Sql
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Task<Client> FindClient(long chatId);
    
    
    
    
       
    /// <summary>
    /// Add Sql to Board
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="NickNmae"></param>
    /// <returns></returns>
    public Task<Board?> AddBoard(Update update, CancellationToken cancellationToken,string NickName);
    
    
    
    
    
    
    /// <summary>
    ///  Get Boards from Sql and Send these Board to Client
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="index"></param>
    /// <exception cref="NotImplementedException"></exception>
    public Task PrintBoard(Update update, CancellationToken cancellationToken, long index);
    
    
    
    
    /// <summary>
    /// Write Message to Board and save to Sql 
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="NickBoard"></param>
    /// <exception cref="NotImplementedException"></exception>
    public Task WriteToBoardMessage(Update update, CancellationToken cancellationToken, string NickBoard);


}