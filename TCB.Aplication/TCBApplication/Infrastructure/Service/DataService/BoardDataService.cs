using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.DataService;

public class BoardDataService : DataServiceBase<Board>
{
    public BoardDataService(DataContext context) : base(context)
    {
    }
}