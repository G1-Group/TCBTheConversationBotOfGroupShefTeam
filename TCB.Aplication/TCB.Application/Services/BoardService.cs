using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services.Interface;

namespace TCB.Aplication.Services;

public class BoardService:IBoardService
{
    private readonly BoardDataSarvice _boardDataSarvice;

    public BoardService(BoardDataSarvice boardDataSarvice)
    {
        _boardDataSarvice = boardDataSarvice;
    }
    
    public async Task<Board> Add(Board data)
    {
        Board board = await _boardDataSarvice.FindByIdData(data.Id);
        if (board is not null)
            return board;
        return await _boardDataSarvice.CreateData(data);
    }

    public async Task<Board> Delete(Board data)
    {
        Board board =await _boardDataSarvice.FindByIdData(data.Id);
        if (board is null)
            return null;

        else
        {
            _boardDataSarvice.DeleteData(data.Id);
            return board;
        }

    }

    public async Task<Board> Update(long Id,Board data)
    {
        return await _boardDataSarvice.UpdateData(Id, data);
    }

    public async Task<List<Board>> GetAllModel()
    {
        return await _boardDataSarvice.GetAllData();
    }

    public async Task<Board> FindByIdModel(long Id)
    {
        return await _boardDataSarvice.FindByIdData(Id);
    }
    

    public async Task<Board> FindByNickNameModel(string nickName)
    {
        return await _boardDataSarvice.FindByNickName(nickName);
    }
}