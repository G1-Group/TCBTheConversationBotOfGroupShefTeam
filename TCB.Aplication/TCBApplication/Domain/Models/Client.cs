using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCB.Aplication.Domain;

[Table("client")]
public class Client : ModelBase
{
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("user_name")]
    
    [NotMapped]
    public User  User { get; set; }
    public long UserName { get; set; }
    [Column("nick_name")]
    public string NickName { get; set; }
    [Column("is_premium")]
    public bool IsPremium { get; set; }
    [Column("status")]
    public ClientStatus Status { get; set; }
    
    [NotMapped] 
    public List<Message> Messages { get; set; }
    
    [NotMapped]
    public List<Board> Boards { get; set; }
    
    [NotMapped]
    public List<AnonymChat> ToConversations { get; set; }
    
    [NotMapped] 
    public List<AnonymChat> FromConversations { get; set; }
    
}