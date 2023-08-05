namespace TCB.Aplication.Domain;

public class MessageTCB : ModelBase
{
    public string text { get; set; }
    public long? FromId { get; set; }
    public DateTime time { get; set; }
    public long BoardId { get; set; }
    public long? chatId { get; set; }
    public MessageTypeTCB status { get; set; }
    public MessageStatus messageStatus { get; set; }
}
