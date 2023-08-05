namespace TCB.Aplication.Domain;

public class Board:ModelBase
{
    public string NickName { get; set; }
    public long OwnerId { get; set; }
    public List<MessageTCB> messageTcbs { get; set; }
}

