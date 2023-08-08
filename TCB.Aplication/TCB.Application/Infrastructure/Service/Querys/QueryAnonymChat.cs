namespace TCB.Aplication.Domain.Querys;

public static class QueryAnonymChat
{
    public static string SelectQuery = $"SELECT * FROM telegrambot.AnonyChat ;";
    
    public static string SelectByIdQuery = $"SELECT * FROM telegrambot.AnonyChat  WHERE id=@p0";

    public static string SelectByClientChatIdQuery =
        $"SELECT * FROM telegrambot.AnonyChat  WHERE client_chat_id_first=@p1 or client_chat_id_last=@p1";

    
    public static string SelectByStatusQuery = $"SELECT * FROM telegrambot.AnonyChat  WHERE status=@p3";





    public static string InsertQuery =
        $"INSERT INTO telegrambot.AnonyChat  (id,client_chat_id_first,client_chat_id_last,status,time) values (@p0,@p1,@p2,@p3,@p4)";


    
    
    public static string UpdateQuery =
        $"UPDATE telegrambot.AnonyChat  SET client_chat_id_first = @p1 , client_chat_id_last = @p2 , status=@p3 , time = @p4  WHERE id = @p0 ";



    public static string DeleteQuery = $"DELETE telegrambot.AnonyChat  WHERE id = @p0";
    
    
    


}