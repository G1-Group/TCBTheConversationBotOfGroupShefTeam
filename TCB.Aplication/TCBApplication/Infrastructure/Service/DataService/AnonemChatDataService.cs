using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.DataService;

public class AnonemChatDataService : DataServiceBase<AnonymChat>
{
    public AnonemChatDataService(DataContext context) : base(context)
    {
    }
}