using Microsoft.VisualBasic;
using Npgsql;
using TCB.Aplication.DataProviderFolder;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service.Interface;

namespace TCB.Aplication.Infrastructure.Service;

public class BoardDataSarvice:DataProvider
{
    
    public BoardDataSarvice(string cannectionString) : base(cannectionString)
    {
        
    }
    
    
    
    /// <summary>
    /// Add board to Sql and return Board 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<Board> CreateData(Board data)
    {
        
        var result= await this.ExecuteNonResult(QueryBoard.InsertQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", data.Id),
            new NpgsqlParameter("@p1", data.OwnerId),
            new NpgsqlParameter("@p2", data.NickName)
        });
        return await FindByIdData(data.Id);
    }
    
    
    
    
    
//______________________________________
    /// <summary>
    /// Update Data from Sql where Id and return Board
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<Board> UpdateData(long Id, Board data)
    {
        var result= await this.ExecuteNonResult(QueryBoard.UpdateQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id),
            new NpgsqlParameter("@p1", data.OwnerId),
            new NpgsqlParameter("@p2", data.NickName)
        });
        return await FindByIdData(Id);
    }

    
    
    
    
    /// <summary>
    /// Get All Boards from Sql
    /// </summary>
    /// <returns></returns>
    public async Task<List<Board>> GetAllData()
    {
        var reader = await this.ExecuteWithResult(QueryBoard.SelectQuery(), null);
        List<Board> boards = new List<Board>();
        while (reader.Read())
            boards.Add(ReaderDataModel(reader));
        return boards;
    }

    
    
    /// <summary>
    /// Find Board Id from Sql where Id and return Board
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<Board> FindByIdData(long Id)
    {
        var reader = await this.ExecuteWithResult(QueryBoard.SelectByIdQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });
        List<Board> boards = new List<Board>();
        while (reader.Read())
            boards.Add(ReaderDataModel(reader));
        return boards.FirstOrDefault();

    }
    
    
    
    
    /// <summary>
    /// Delete Board from Sql and return Board 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<Board> DeleteData(long Id)
    {
        Board board =await FindByIdData(Id);
        var result = await ExecuteNonResult(QueryBoard.DeleteQuery(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", Id)
        });
        return board;
    }

    
    
    
    /// <summary>
    /// Find Board NickName from Sql NickName and return Board
    /// </summary>
    /// <param name="nickName"></param>
    /// <returns></returns>
    public async Task<Board> FindByNickName(string nickName)
    {
        var reader = await this.ExecuteWithResult(QueryBoard.SelectByNickName(), new NpgsqlParameter[]
        {
            new NpgsqlParameter("@p0", nickName)
        });
        List<Board> boards = new List<Board>();
        while (reader.Read())
            boards.Add(ReaderDataModel(reader));
        return boards.FirstOrDefault();   
    }


    
    /// <summary>
    /// Convert to Board 
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    private Board ReaderDataModel(NpgsqlDataReader reader)
    {
        return new Board()
        {
            Id = reader.GetInt64(0),
            OwnerId = reader.GetInt64(1),
            NickName = reader.GetString(2)
        };
    }
    
}