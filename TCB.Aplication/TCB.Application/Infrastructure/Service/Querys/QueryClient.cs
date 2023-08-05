namespace TCB.Aplication.Domain.Querys;

public static class QueryClient
{
    public static string SelectQuery = $"SELECT * FROM \"Telegrambot\".Client";
    
    public static string SelectByIdQuery = $"SELECT * FROM \"Telegrambot\".Client WHERE id = @p0";

    public static string SelectByUserIdQuery = $"SELECT * FROM \"Telegrambot\".Client WHERE user_id= @p1";
    
    public static string SelectByChatIdQuery = $"SELECT * FROM \"Telegrambot\".Client WHERE chat_id = @p2";
    
    public static string SelectByNickNameQuery = $"SELECT * FROM \"Telegrambot\".Client WHERE nickName = @p3";
    
    
    
    public static string InsertQuery = $"INSERT INTO \"Telegrambot\".Client (id  , user_id , chat_id , nickName, status , isPremium , clientInAnonymChat)" +
                                       $" VALUES(@p0 , @p1 , @p2 , @p3 , @p4 , @p5, @p6 )";


    public static string UpdateQuery = $"UPDATE \"Telegrambot\".Client c  SET  c.user_id = @p1 , c.chat_id = @p2 , c.mickName = @p3 , c.status = @p4 , c.isPremium = @p5  , c.clientInAnonymChat = @p6 WHERE id = @p0";

    

    public static string DeleteQuery = $"DELETE FROM \"Telegrambot\".Client WHERE id = @p0";
}