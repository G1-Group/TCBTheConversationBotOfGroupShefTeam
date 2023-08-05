namespace TCB.Aplication.Domain;

public class MessageTCB:ModelBase
{
    public string text { get; set; }
    public long FromId { get; set; }
    public DateTime time { get; set; }
    public long BoardId { get; set; }
}