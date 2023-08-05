namespace TCB.Aplication.Domain.Querys;

public static class MessageTCBQuery
{
    
    
    
    public static string SelectQuery()
    {
        return $"select * from \"Telegrambot\".MessageTCB";
    }
    public static string SelectByIdQuery()
    {
        return $"select * from \"Telegrambot\".MessageTCB  where id=@p0";
    }
    public static string SelectByFromId()
    {
        return $"select * from \"Telegrambot\".MessageTCB   where from_id=@p0;";
    }

    public static string SelectByBoardId()
    {
        return $"select *  from \"Telegrambot\".MessageTCB where board_id=@p0;";
    }




    public static string InsertQuery()
    {
        return $"Insert into \"Telegrambot\".MessageTCB ( id ,from_id , board_id , chat_id,text, time , status ,message_status) values (@p,@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
    }



    

    public static string UpdateQuery()
    {
        return $"UPDATE \"Telegrambot\".MessageTCB SET from_id = @p1 , board_id = @p2 , chat_id = @p3 ,text = @p4 , time = @p5 , status=@p6 ,message_status=@p7  WHERE id = @p0 ;";
    }

    
    
    
    
    public static string DeleteQuery()
    {
        return $"delete  \"Telegrambot\".MessageTCB  WHERE id=@p0;";
    }
}