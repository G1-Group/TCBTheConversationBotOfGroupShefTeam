using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IDataServiceAnonymChat:IDataSarvice<AnonymChat>
{
    public Task<AnonymChat> FindByFromIdOrClientId(long Id);
    public Task<AnonymChat> FindByStatus(int role);
}