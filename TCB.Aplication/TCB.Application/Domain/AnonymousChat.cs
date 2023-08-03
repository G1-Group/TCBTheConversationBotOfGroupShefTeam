namespace TCB.Aplication.Domain;

public class AnonymousChat
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public long FromId { get; set; }
    public long ToId { get; set; }
    public ChatState State { get; set; }
}