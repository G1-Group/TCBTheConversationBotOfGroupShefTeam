using TCB.Aplication.Domain;
using TCB.Aplication.Service.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;
using MessageType = Telegram.Bot.Types.Enums.MessageType;

namespace TCB.Aplication.Service;

public class BoardService:IBoard
{
    private readonly ITelegramBotClient telegramBotClient;
    private string messageText;
    private string NickName;
    private Board board;



    public BoardService(ITelegramBotClient telegramBotClient)
    {
        this.telegramBotClient = telegramBotClient;
    }
    
    
    

    public async Task Start(Update update, CancellationToken cancellationToken)
    {
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
    
    

    
    
    

    public async Task CreateBoard(Update update, CancellationToken cancellationToken)
    {

        try
        {
            if (FindClient(update.Message.Chat.Id) is null )
            {
                SendMessage(update, cancellationToken, "Sizga ruxsat yuq");
                Start(update, cancellationToken);
                return;
            }


            if (update.Message.Type != MessageType.Text)
            {
                SendMessage(update, cancellationToken, "Format Exeption");
                Start(update, cancellationToken);
                return;
            }

            messageText = update.Message.Text;
            
            if(FindBoardNickName(messageText).Result is not null)
            {
                SendMessage(update, cancellationToken, "This nickName is Busy");
                Start(update, cancellationToken);
                return;
            }

            if (AddBoard(update, cancellationToken, messageText) is null)
            {
                
                SendMessage(update, cancellationToken, "Sorry Board could not be created");
                Start(update, cancellationToken);
                return;
            }
            SendMessage(update, cancellationToken, "Created Board 🥳🎉🎉");
            Start(update, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
    
    
    
    
    
    
    
    
    
    
    
    public async Task ListAllBoard(Update update, CancellationToken cancellationToken)
    {
        try
        {
            if(true)
                PrintBoard(update, cancellationToken, 0);


            messageText = update.Message.Text;

            if (messageText != "yes")
            {
                Start(update, cancellationToken);
                return;
            }

            NickName = update.Message.Text;

            board = FindBoardNickName(NickName).Result;

            WriteToBoardMessage(update,cancellationToken,NickName);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
   
    public async Task Back(Update update, CancellationToken cancellationToken)
    {
        
    }
    
    
    
    
     
    public async Task<Board?> AddBoard(Update update, CancellationToken cancellationToken,string NickName)
    {
        if (NickName is null)
            return null;
        
        
        return null;
    }

    
    
    

    public async Task PrintBoard(Update update, CancellationToken cancellationToken, long index)
    {
        
    }
    
    
    
    
    

    public async Task WriteToBoardMessage(Update update, CancellationToken cancellationToken, string NickBoard)
    {
        try
        {
            if (board is null)
            {
                SendMessage(update,cancellationToken,"exeption ");
                Start(update, cancellationToken);
                return;
            }
            
            
            if (update.Message.Type != MessageType.Text)
            {
                SendMessage(update, cancellationToken, "please write a text");
                Start(update, cancellationToken);
                return;
            }
            board.Messages.Add(new MessageTCB()
            {
                FromId = update.Message.From.Id,
                ChatId = update.Message.Chat.Id,
                BoardId = board.Id,
                text = update.Message.Text,
                time = DateTime.Now
            });
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }



    public async Task<Board?> FindBoardNickName(string text)
    {
        return null;
    }




    public async Task SendMessage(Update update, CancellationToken cancellationToken, string text)
    {
        try
        {
            
            Message message = await telegramBotClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: text,
                cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Client> FindClient(long chatId)
    {
        
        
        return null;
    }
}