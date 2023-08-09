using TCB.Aplication.TelegramBot.Managers;

namespace TCB.Aplication.TelegramBot.Context.Extension;

public static class ContextExtension
{
    public static async Task Forward( this ControllerContext context, ControllerManager controllerManager)
    {
        ControllerBase baseController = controllerManager.GetControllerBySessionData(context.Session);
        await baseController.Handle(context);
    }
}