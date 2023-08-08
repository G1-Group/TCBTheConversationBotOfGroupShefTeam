namespace TCB.Aplication.Domain.Querys;

public static class QueryMessage
{
    
    
    
    public static string SelectQuery()
    {
        return $"select * from telegrambot.Message";
    }
    public static string SelectByIdQuery()
    {
        return $"select * from telegrambot.Message  where id=@p0 ;";
    }
    public static string SelectByFromId()
    {
        return $"select * from telegrambot.Message   where from_id=@p0;";
    }

    public static string SelectByBoardId()
    {
        return $"select *  from telegrambot.Message where board_id=@p0;";
    }
    public static string SelectByAnonymChatId()
    {
        return $"select *  from telegrambot.Message where anonym_chat_id=@p0;";
    }
    
    public static string InsertQuery()
    {
        return $"Insert into telegrambot.Message ( id ,from_id , board_id , chat_id, text, time , status , message_status ) values (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
    }
    
    public static string UpdateQuery()
    {
        return $"UPDATE telegrambot.Message SET from_id = @p1 , board_id = @p2 , chat_id = @p3 ,text = @p4 , time = @p5 , status=@p6 ,message_status=@p7  WHERE id = @p0;";
    }
    
    public static string DeleteQuery()
    {
        return $"DELETE telegrambot.Message  WHERE id=@p0;";
    }
}