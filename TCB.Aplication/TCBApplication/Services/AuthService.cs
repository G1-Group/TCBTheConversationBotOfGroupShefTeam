using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services.Interface;

namespace TCB.Aplication.Services;

public class AuthService :  IAuthService
{
    private ClientDataService _clientDataService;
    private UserDataService _userDataService;

    public AuthService(ClientDataService clientDataService , UserDataService userDataService)
    {
        this._userDataService = userDataService;
        this._clientDataService =clientDataService;
    }
    
    
    
    public async Task<User> Registration(User user,string? NickName)
    {
        if (string.IsNullOrEmpty(NickName) || user is null)
        {
            Console.WriteLine("xatolik bor user yoki niuck name null");
            return null;
        }

        if (await _userDataService.FindByPhoneNumber(user.PhoneNumber) is not null)
        {
            Console.WriteLine("User's Phone Number is Active");
            return null;
        }

        await _userDataService.CreateData(user);
        user =await _userDataService.FindByPhoneNumber(user.PhoneNumber);
        await _clientDataService.CreateData(new Client()
        {
            NickName = NickName,
            Status = ClientStatus.Enabled,
            UserName = user.TelegramChatId,
            UserId = user.Id
        });
        return user;
    }




    public async Task<Client> Login(string phoneNumber , string password)
    {
        var user = await _userDataService.FindByPassword(phoneNumber);
        if (user is null)
            return null;
        
        if (user.Password == password)
            return await _clientDataService.FindByUserId(user.Id);

        return null;
    }
    
    
    
}