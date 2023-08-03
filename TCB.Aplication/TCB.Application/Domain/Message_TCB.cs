namespace TCB.Aplication.Domain;

public class MessageTCB:ModelBase
{
    public long? ChatId { get; set; }
    public string text { get; set; }
    public long FromId { get; set; }
    public DateTime time { get; set; }
    public long? BoardId { get; set; }
    
}