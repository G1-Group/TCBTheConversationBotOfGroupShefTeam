using TCB.Aplication.Domain;

namespace TCB.Aplication.Services.Interface;

public interface IAuthService
{
    public Task  Registration(User user);

    public Task<Client> Login(string phoneNumber , string password);
}