namespace TCB.Aplication.Domain;

public class AnonymousChat : BaseModel
{
    public DateTime Date { get; set; }
    public long FromId { get; set; }
    public long ToId { get; set; }
    public ChatState State { get; set; }
}