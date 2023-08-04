namespace TCB.Aplication.Domain.Querys;

public static class QueryUser
{
    public static string SelectQuery = $"SELECT * FROM SQL.User";
    
    public static string SelectByIdQuery = $"SELECT * FROM SQL.User WHERE id = @p0";
    
    
    public static string SelectByClientIdQuery = $"SELECT * FROM SQL.User WHERE client_id = @p1";
    
    
    public static string SelectByPhoneNumberQuery = $"SELECT * FROM SQL.User WHERE phone_number = @p2";
    
    
    public static string SelectByPasswordQuery = $"SELECT * FROM SQL.User WHERE password = @p3";


    public static string InsertQuery = $"INSERT INTO SQL.User (id , client_id , phone_number , password)" +
                                       $" VALUES(@p0 , @p1 ,@p2 , @p3)";

    public static string UpdateQuery =
        $"UPDATE SQL.User u SET id = @p0 , client_id = @p1 , phone_number = @p2 , password = @p3";

    public static string DeleteQuery = $"DELETE FROM SQL.User WHERE id = @p0";
}