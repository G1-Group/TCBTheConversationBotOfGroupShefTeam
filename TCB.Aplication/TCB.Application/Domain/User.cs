namespace TCB.Aplication.Domain;

public class User : ModelBase
{
    public long TelegramClientId { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    
    
}