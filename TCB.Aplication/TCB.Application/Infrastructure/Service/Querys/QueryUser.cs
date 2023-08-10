namespace TCB.Aplication.Domain.Querys;

public static class QueryUser
{
    public static string SelectQuery = $"SELECT * FROM telegrambot.User";
    
    public static string SelectByIdQuery = $"SELECT * FROM telegrambot.User WHERE id = @p0";
    
    
    public static string SelectByChatIdQuery = $"SELECT * FROM telegrambot.User WHERE chat_id = @p1";
    
    
    public static string SelectByPhoneNumberQuery = $"SELECT * FROM telegrambot.User WHERE phone_number = @p2";
    
    
    public static string SelectByPasswordQuery = $"SELECT * FROM telegrambot.User WHERE password = @p3";


    public static string InsertQuery = $"INSERT INTO telegrambot.User (id , chat_id , phone_number , password) VALUES(@p0 , @p1 ,@p2 , @p3)";

    public static string UpdateQuery =
        $"UPDATE telegrambot.User u SET id = @p0 , chat_id = @p1 , phone_number = @p2 , password = @p3";

    public static string DeleteQuery = $"DELETE FROM telegrambot.User WHERE id = @p0";
}