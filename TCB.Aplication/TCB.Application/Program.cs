


using System.Threading.Channels;
using TCB.Aplication.Domain;
using TCB.Aplication.Domain.Querys;
using TCB.Aplication.Infrastructure.Service;


const string CONNECTION_STRING = "Host=localhost:5432;" +
                                 "Username=postgres;" +
                                 "Password=Ogabek1407;" +
                                 "Database=SqlBot";




BoardDataSarvice boardata=new BoardDataSarvice(CONNECTION_STRING);

Board board = new Board()
{
    Id = 2,
    OwnerId = 3,
    NickName = "Anonymis2"
};



Board board1 = new Board()
{
    Id = 2,
    OwnerId = 3,
    NickName = "Azim2"
};

var result1=await boardata.CreateData(board1);
var result2=await boardata.CreateData(board);


//var result = await boardata.UpdateData(1,board1);

 var result = await boardata.GetAllData();
//Console.Write(result.NickName+result.Id+result.OwnerId);
foreach (Board board2 in result)
 {
     Console.WriteLine(board2.Id +" "+board2.OwnerId+" "+board2.NickName);
 }






