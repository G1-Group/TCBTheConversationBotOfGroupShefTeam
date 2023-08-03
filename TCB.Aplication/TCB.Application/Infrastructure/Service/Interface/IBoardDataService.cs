using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IBoardDataService:IDataSarvice<Board>
{
    public Task<Board> FindByNickName(string nickName);
}