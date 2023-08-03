using TCB.Aplication.Domain;
using Telegram.Bot.Types;

namespace TCB.Aplication.Service.Interface;

public interface IAnonymChatService
{
    /// <summary>
    /// Create anonym chat
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public  Task CreateAnonymChat(Update update, CancellationToken cancellationToken);
    
    /// <summary>
    ///  send message from bot to client
    /// </summary>
    /// <param name="chatId"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="messageFromBot"></param>
    /// <returns></returns>
    public Task SendMessage(ChatId chatId, CancellationToken cancellationToken, string messageFromBot);

    /// <summary>
    /// send  message in anonym chat from bot to client
    /// </summary>
    /// <param name="update"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="anonymChat"></param>
    /// <returns></returns>
    public Task SendMessageInAnonymChat(Update update, CancellationToken cancellationToken, AnonymChat anonymChat);

    /// <summary>
    /// all methods vors in this methods
    /// </summary>
    /// <returns></returns>
    public Task Initialize();


}