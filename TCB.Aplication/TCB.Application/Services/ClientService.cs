using TCB.Aplication.Domain;
using TCB.Aplication.Services.Interface;

namespace TCB.Aplication.Services;

public class ClientService : IService<User>
{
    private List<User> _users;

    public ClientService()
    {
        this._users = new List<User>();
    }
    public void Add(User data)
    {
        this._users.Add(data);
    }

    public void Delete(User data)
    {
        this._users.Remove(data);
    }


    public List<User> GetAllModel()
    {
        return this._users;
    }

    public User FindModel(long id)
    {
        return this._users.Find(x => x.Id == id);
    }


    public void AddRange(List<User> data)
    {
        this._users.AddRange(data);
    }
    public void Update(User data)
    {
    }
}