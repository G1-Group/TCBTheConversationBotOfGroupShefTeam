using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.DataService;

public class UserDataService : DataServiceBase<User>
{
    public UserDataService(DataContext context) : base(context)
    {
    }
}