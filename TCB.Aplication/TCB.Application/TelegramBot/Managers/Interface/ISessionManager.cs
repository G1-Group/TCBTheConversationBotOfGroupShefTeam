namespace TCB.Aplication.TelegramBot.Managers.Interface;

public interface ISessionManager
{
    public Task<Session> GetSessionByChatId(long chatId);
}