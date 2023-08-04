namespace TCB.Aplication.Domain.Querys;

public static class QueryAnonymChat
{
    public static string SelectQuery = $"SELECT * FROM SQL.ANONYMCHAT ;";
    
    public static string SelectByIdQuery = $"SELECT * FROM SQL.ANONYMCHAT WHERE id=@p0";

    public static string SelectByFromIdOrClientIdQuery =
        $"SELECT * FROM SQL.ANONYMCHAT WHERE from_id=@p1 or client_id=@p1";

    
    public static string SelectByStatusQuery = $"SELECT * FROM SQL.ANONYMCHAT WHERE status=@p3";





    public static string InsertQuery =
        $"INSERT INTO SQL.ANONYMCHAT (id,from_id,client_id,status,create_time) values (@p0,@p1,@p2,@p3,@p4)";


    
    
    public static string UpdateQuery =
        $"UPDATE SQL.ANONYMCHAT SET from_id = @p1 , client_id = @p2 , status=@p3 , create_time = @p4  WHERE id = @p0 ";



    public static string DeleteQuery = $"DELETE SQL.ANONYMCHAT WHERE id = @p0";
    
    
    


}