namespace TCB.Aplication.Domain.Querys;

public static class QueryMessage
{
    
    
    
    public static string SelectQuery()
    {
        return $"select * from \"Telegrambot\".Message";
    }
    public static string SelectByIdQuery()
    {
        return $"select * from \"Telegrambot\".Message  where id=@p0 ;";
    }
    public static string SelectByFromId()
    {
        return $"select * from \"Telegrambot\".Message   where from_id=@p0;";
    }

    public static string SelectByBoardId()
    {
        return $"select *  from \"Telegrambot\".Message where board_id=@p0;";
    }

    public static string InsertQuery()
    {
        return $"Insert into \"Telegrambot\".Message ( id ,from_id , board_id , chat_id, message, time , status ) values (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
    }
    
    public static string UpdateQuery()
    {
        return $"UPDATE \"Telegrambot\".Message SET from_id = @p1 , board_id = @p2 , chat_id = @p3 ,message = @p4 , time = @p5 , status=@p6   WHERE id = @p0;";
    }
    
    public static string DeleteQuery()
    {
        return $"DELETE \"Telegrambot\".MessageTCB  WHERE id=@p0;";
    }
}