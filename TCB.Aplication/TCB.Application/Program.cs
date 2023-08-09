

using System.Text.RegularExpressions;
using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;

class Program
{

    public static async Task Main(string[] args)
    {
        new TelegramBotStartService().Start().Wait();

      Console.ReadKey();

     // Console.WriteLine(test("Ab2332_m"));
    }
    public static bool IsValidPhone(string Phone)
    {
        try
        {
            if (string.IsNullOrEmpty(Phone))
                return false;
            var r = new Regex(@"^(?!.([A-Za-z0-9])\1{1})(?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])(?=.?[#?!@$%^&-]).{8,}$");
            return r.IsMatch(Phone);

        }
        catch (Exception)
        {
            throw;
        }
    }
    

}








