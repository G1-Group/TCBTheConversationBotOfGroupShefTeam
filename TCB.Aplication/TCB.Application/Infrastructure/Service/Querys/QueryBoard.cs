namespace TCB.Aplication.Domain.Querys;

public static class QueryBoard
{
    
    
    public static string SelectQuery()
    {
        return $"select * from telegrambot.Board";
    }
    public static string SelectByIdQuery()
    {
        return $"select * from telegrambot.Board as t where t.id=@p0";
    }
    public static string SelectByNickName()
    {
        return $"select * from telegrambot.Board as t where t.nick_name=@p0;";
    }

    
    
    
    
    public static string InsertQuery()
    {
        return $"Insert into telegrambot.Board (id,owner_id,nick_name) values (@p0,@p1,@p2)";
    }



    

    public static string UpdateQuery()
    {
        return $"UPDATE telegrambot.Board SET owner_id = @p1 , nick_name = @p2  WHERE id = @p0 ;";
    }

    
    
    
    
    public static string DeleteQuery()
    {
        return $"delete  telegrambot.Board  WHERE id=@p0;";
    }
    
}