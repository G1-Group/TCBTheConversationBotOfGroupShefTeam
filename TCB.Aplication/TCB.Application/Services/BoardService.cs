using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services.Interface;

namespace TCB.Aplication.Services;

public class BoardService:IBoardService
{
    private readonly BoardDataSarvice _boardDataSarvice;
    private readonly MessageTCBDataService messageTcbDataService;

    public BoardService(BoardDataSarvice boardDataSarvice,MessageTCBDataService messageTcbDataService)
    {
        _boardDataSarvice = boardDataSarvice;
        messageTcbDataService = messageTcbDataService;
    }
    
    private async Task<Board> Add(Board data)
    {
        Board board = await _boardDataSarvice.FindByIdData(data.Id);
        if (board is not null)
            return board;
        return await _boardDataSarvice.CreateData(data);
    }


    public async Task<Board> CreateBoard(string NickName,long OwnerId)
    {
        return  await Add(new Board()
        {
            NickName = NickName,
            OwnerId = OwnerId
        });
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

    public async Task WriteMessageToBoard(long BoardId, MessageTCB messageTcb)
    {
        if(messageTcb is null)
            return;
        messageTcb.messageStatus = MessageStatus.NoRead;
        messageTcbDataService.CreateData(messageTcb);
    }

    public async Task<List<MessageTCB>> ReadMessageToBoard(long Id)
    {
        List<MessageTCB> messages= await messageTcbDataService.GetAllFindBoardId(Id);
        if (messages is null)
            return null;
        foreach (var message in messages)
        {
            message.messageStatus = MessageStatus.Read;
            messageTcbDataService.UpdateData(message.Id, message);
        }
        return messages;
    }
}