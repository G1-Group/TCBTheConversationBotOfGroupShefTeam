namespace TCB.Aplication.Domain;

public class User : ModelBase
{
    public long Id { get; set; }
    public long TelegramClientId { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}