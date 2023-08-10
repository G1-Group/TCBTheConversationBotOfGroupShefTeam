using System.Runtime.CompilerServices;
using TCB.Aplication.TelegramBot.Managers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TCB.Aplication.TelegramBot;

public class ControllerExtension
{
    
    public static async Task Forward(ControllerContext context, ControllerManager controllerManager)
    {
        ControllerBase controllerBase =  controllerManager.GetControllerBySessionData(context.Session);
        await controllerBase.Handle(context);
    }

    public static async Task<Message> SendMessage(ControllerContext context, string? text)
    {
        return await TelegramBotStartService._telegramBotClient.SendTextMessageAsync(
            chatId: context.Update.Message.Chat?.Id, text);
    }
}