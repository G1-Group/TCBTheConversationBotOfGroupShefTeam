using System.ComponentModel;

namespace TCB.Aplication.Domain;

public class Board:ModelBase
{
    [Description("nick_name")]
    public string NickName { get; set; }
    
    [Description("owner_id")]
    public long OwnerId { get; set; }
    
    [Description("messageTcbs")]
    public List<MessageTCB> messageTcbs { get; set; }
}

