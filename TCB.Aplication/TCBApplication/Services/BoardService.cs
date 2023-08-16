using TCB.Aplication.Domain;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services.Interface;

namespace TCB.Aplication.Services;

public class BoardService:IBoardService,IService<Board>
{
    private readonly BoardDataSarvice _boardDataSarvice;
    private readonly MessageDataServise _messageDataService;

    public BoardService(BoardDataSarvice boardDataSarvice,MessageDataServise messageDataService)
    {
        _boardDataSarvice = boardDataSarvice;
        messageDataService = messageDataService;
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
    

    public async Task<Board> FindById(long Id)
    {
        return await _boardDataSarvice.FindByIdData(Id);
    }
    

    public async Task<Board> FindByNickName(string nickName)
    {
        return await _boardDataSarvice.FindByNickName(nickName);
    }

    public async Task WriteMessageToBoard(long BoardId, Message message)
    {
        if(message is null)
            return;
        message.messageStatus = MessageStatus.NoRead;
        _messageDataService.CreateData(message);
    }

    public async Task<List<Message>> ReadMessageToBoard(long Id)
    {
        List<Message> messages= await _messageDataService.GetAllFindBoardId(Id);
        if (messages is null)
            return null;
        foreach (var message in messages)
        {
            message.messageStatus = MessageStatus.Read;
            _messageDataService.UpdateData(message.Id, message);
        }
        return messages;
    }
}