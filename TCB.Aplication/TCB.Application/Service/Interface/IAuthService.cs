using Telegram.Bot.Types;

namespace TCB.Aplication.Service.Interface;


public interface IAuthService
{
    /// <summary>
    /// Start berilganda
    /// </summary>
    /// <returns></returns>
    Task StartMenu();
    
    
    
    /// <summary>
    /// tilni tanlash jarayoni 
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task LanguageMenu(Update update, CancellationToken cancellationToken);
    
    
    
    
    /// <summary>
    /// Registration yoki  Login tanlash
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RegistrationAndLogin(Update update, CancellationToken cancellationToken);
    
    
    
    /// <summary>
    /// Registration o'tish
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Registration(Update update, CancellationToken cancellationToken);


    /// <summary>
    /// Login qilish
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Login(Update update, CancellationToken cancellationToken);




    /// <summary>
    /// Find User From SQL 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task FindUserFromSql(long userId);

}