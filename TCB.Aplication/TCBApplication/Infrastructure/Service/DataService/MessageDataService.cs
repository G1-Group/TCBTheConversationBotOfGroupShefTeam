using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.DataService;

public class MessageDataService : DataServiceBase<Message>
{
    public MessageDataService(DataContext context) : base(context)
    {
    }
}