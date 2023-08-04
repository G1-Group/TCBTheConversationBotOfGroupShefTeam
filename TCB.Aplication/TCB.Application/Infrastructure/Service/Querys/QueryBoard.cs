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
        return $"select * from Pgslq.Board as t where t.nick_name=@p0;";
    }

    
    
    
    
    public static string InsertQuery()
    {
        return $"Insert into Pgslq.Board (id,owner_id,nick_name) values (@p0,@p1,@p2)";
    }



    

    public static string UpdateQuery()
    {
        return $"UPDATE Pgslq.Board SET owner_id = @p1 , nick_name = @p2  WHERE course_id = @p0 ;";
    }

    
    
    
    
    public static string DeleteQuery()
    {
        return $"delete  Pgsql.Board  WHERE id=@p0;";
    }
    
}