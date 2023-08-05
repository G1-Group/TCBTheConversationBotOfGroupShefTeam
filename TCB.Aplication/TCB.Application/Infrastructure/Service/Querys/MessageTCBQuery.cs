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
        return $"Insert into \"Telegrambot\".MessageTCB (id,text,from_id,time,board_id) values (@p0,@p1,@p2,@p3,@p4)";
    }



    

    public static string UpdateQuery()
    {
        return $"UPDATE \"Telegrambot\".MessageTCB SET text=@p1 , from_id = @p2 , time = @p3 , board_id = @p4  WHERE id = @p0 ;";
    }

    
    
    
    
    public static string DeleteQuery()
    {
        return $"delete  \"Telegrambot\".MessageTCB  WHERE id=@p0;";
    }
}