using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface IAuthService
{
    public Task<User>  Registration(User user,string NickName);

    public Task<Client> Login(string phoneNumber , string password);
}