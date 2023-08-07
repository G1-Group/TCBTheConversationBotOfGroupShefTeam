namespace TCB.Aplication.Domain.Querys;

public static class QueryClient
{
    public static string SelectQuery = $"SELECT * FROM telegrambot.Client";
    
    public static string SelectByIdQuery = $"SELECT * FROM telegrambot.Client WHERE id = @p0";

    public static string SelectByUserIdQuery = $"SELECT * FROM telegrambot.Client WHERE user_id= @p1";
    
    public static string SelectByChatIdQuery = $"SELECT * FROM telegrambot.Client WHERE chat_id = @p2";
    
    public static string SelectByNickNameQuery = $"SELECT * FROM telegrambot.Client WHERE nickName = @p3";
    
    
    
    public static string InsertQuery = $"INSERT INTO telegrambot.Client (id  , user_id , chat_id , nickName, status , isPremium , clientInAnonymChat)" +
                                       $" VALUES(@p0 , @p1 , @p2 , @p3 , @p4 , @p5, @p6 )";


    public static string UpdateQuery = $"UPDATE telegrambot.Client c  SET  c.user_id = @p1 , c.chat_id = @p2 , c.mickName = @p3 , c.status = @p4 , c.isPremium = @p5  , c.clientInAnonymChat = @p6 WHERE id = @p0";

    

    public static string DeleteQuery = $"DELETE FROM telegrambot.Client WHERE id = @p0";
}