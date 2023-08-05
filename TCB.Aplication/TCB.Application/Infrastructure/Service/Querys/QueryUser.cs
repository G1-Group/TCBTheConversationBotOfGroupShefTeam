namespace TCB.Aplication.Domain.Querys;

public static class QueryUser
{
    public static string SelectQuery = $"SELECT * FROM \"Telegrambot\".user";
    
    public static string SelectByIdQuery = $"SELECT * FROM \"Telegrambot\".user WHERE id = @p0";
    
    
    public static string SelectByUserIdQuery = $"SELECT * FROM \"Telegrambot\".user WHERE client_id = @p1";
    
    
    public static string SelectByPhoneNumberQuery = $"SELECT * FROM \"Telegrambot\".user WHERE phone_number = @p2";
    
    
    public static string SelectByPasswordQuery = $"SELECT * FROM \"Telegrambot\".user WHERE password = @p3";


    public static string InsertQuery = $"INSERT INTO \"Telegrambot\".user (id , client_id , phone_number , password)" +
                                       $" VALUES(@p0 , @p1 ,@p2 , @p3)";

    public static string UpdateQuery =
        $"UPDATE \"Telegrambot\".user u SET id = @p0 , client_id = @p1 , phone_number = @p2 , password = @p3";

    public static string DeleteQuery = $"DELETE FROM \"Telegrambot\".user WHERE id = @p0";
}