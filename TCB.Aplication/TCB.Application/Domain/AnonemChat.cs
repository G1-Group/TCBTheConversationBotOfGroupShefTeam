namespace TCB.Aplication.Domain;

public class AnonemChat:ModelBase
{
    public DateTime CreateData { get; set; }
    public long ClientFromId { get; set; }
    public long ConnectClientId { get; set; }
    public AnonymChatStatus Status { get; set; }
}