using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCB.Aplication.Domain;

[Table("boards")]
public class Board:ModelBase
{
    [Column("nick_name")]
    public string NickName { get; set; }
    
    [Column("owner_id")]
    public long OwnerId { get; set; }
    
    [NotMapped] 
    public Client Owner { get; set; }
    
    [NotMapped]
    public List<Message> messages { get; set; }
}

