namespace TCB.Aplication.Domain;

public class Board:ModelBase
{
    public string NickName { get; set; }
    public List<MessageTCB> Messages { get; set; }
    public long ownerid { get; set; }

}

