namespace TCB.Aplication.Domain.Querys;

public static class QueryBoard
{
    
    
    public static string SelectQuery()
    {
        return $"select * from Pgslq.Board";
    }
    public static string SelectByIdQuery()
    {
        return $"select * from Pgslq.Board as t where t.id=@p0";
    }
    public static string SelectByNickName()
    {
        return $"select * from Pgslq.Board as t where t.NickName=@p0;";
    }

    
    
    
    
    public static string InsertQuery()
    {
        return $"Inser into Pgslq.Board (Id,OwnerId,NickName) values (@p0,@p1,@p2)";
    }



    

    public static string UpdateQuery()
    {
        return $"UPDATE Pgslq.Board SET OwnerId = @p1 , NickName = @p2  WHERE course_id = @p0 ;";
    }

    
    
    
    
    public static string DeleteQuery()
    {
        return $"UPDATE Pgsql.Board  WHERE Id=@p0;";
    }
    
}