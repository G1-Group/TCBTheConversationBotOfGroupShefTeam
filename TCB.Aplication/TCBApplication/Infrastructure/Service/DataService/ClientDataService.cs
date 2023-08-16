using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.DataService;

public class ClientDataService : DataServiceBase<Client>
{
    public ClientDataService(DataContext context) : base(context)
    {
    }
}