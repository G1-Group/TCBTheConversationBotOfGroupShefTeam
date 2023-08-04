using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service.Interface;

public interface IDataServiceAnonymChat:IDataSarvice<AnonemChat>
{
    public Task<AnonemChat> FindByFromIdOrClientId(long Id);
    public Task<AnonemChat> FindByStatus(int role);
}