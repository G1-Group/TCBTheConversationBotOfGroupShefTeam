namespace TCB.Aplication.Domain.Querys;

public static class QueryUser
{
    public static string SelectQuery = $"SELECT * FROM telegrambot.user";
    
    public static string SelectByIdQuery = $"SELECT * FROM telegrambot.user WHERE id = @p0";
    
    
    public static string SelectByChatIdQuery = $"SELECT * FROM telegrambot.user WHERE client_id = @p1";
    
    
    public static string SelectByPhoneNumberQuery = $"SELECT * FROM telegrambot.user WHERE phone_number = @p2";
    
    
    public static string SelectByPasswordQuery = $"SELECT * FROM telegrambot.user WHERE password = @p3";


    public static string InsertQuery = $"INSERT INTO telegrambot.user (id , client_id , phone_number , password)" +
                                       $" VALUES(@p0 , @p1 ,@p2 , @p3)";

    public static string UpdateQuery =
        $"UPDATE telegrambot.user u SET id = @p0 , client_id = @p1 , phone_number = @p2 , password = @p3";

    public static string DeleteQuery = $"DELETE FROM telegrambot.user WHERE id = @p0";
}