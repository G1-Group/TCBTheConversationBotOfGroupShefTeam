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
    
    
    
    public async Task Registration(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        await _userDataService.CreateData(new User()
            {
                Id = user.Id,
                TelegramClientId = user.TelegramClientId,
                PhoneNumber = user.PhoneNumber ,
                Password = user.Password
            }
        );
    }

    
    
    public async Task<Client> Login(string phoneNumber , string password)
    {
        var user = await _userDataService.FindByPassword(password);

        if (user.PhoneNumber == phoneNumber)
        {
            return await _clientDataService.FindByIdData(user.Id);
        }

        throw new ArgumentNullException();
    }
    
    
    
}