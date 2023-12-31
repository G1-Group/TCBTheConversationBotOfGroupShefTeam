using TCB.Aplication.Infrastructure.Service;
using TCB.Aplication.Services;
using TCB.Aplication.TelegramBot.Context.Extension;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TCB.Aplication.TelegramBot.Managers;

public class HomeController : ControllerBase
{
    
    public HomeController(ITelegramBotClient botClient , ControllerManager controllerManager ) : base(botClient, controllerManager)
    {
    }

    protected override async Task<bool> HandleAction(ControllerContext context)
    {
        switch (context.Session.Action)
        {
            case nameof(About):
            {
                About(context);
                break;
            }
            case nameof(Help):
            {
                Help(context);
                break;
            }
            
        }

        return true;
    }

    protected override async Task<Task> HandleUpdate(ControllerContext context)
    {
        if (context.Update.Message.Type != MessageType.Text)
             return null;
        switch (context.Update.Message.Text)
        {
            case "/"+nameof(About):
            {
                await About(context);
               break;
            }
            case "/"+nameof(Help):
            {
                await Help(context);
                break;
            }
            case "/Login":
            {
                context.Session.Controller = nameof(LoginController);
                await ContextExtension.Forward(context, _controllerManager);
                break;
            }
            case "/Register":
            {
                context.Session.Controller = nameof(RegisterController);
                await ContextExtension.Forward(context, _controllerManager);
                break;
            }
            
        }

        return null;
    }

    public async Task About(ControllerContext context)
    {
        await this.SendMessage(context, @"Bu bot siz til urganishingi yoki
 o'z biznesingizni yuritishingiz uchun hizmat qiladi. 
Asosiy ustunligimiz suxbatdoshingiz  yoki yuridik shaxs
 sirligicha qolishida.
***
Этот бот предназначен для изучения языка или ведения
 собственного бизнеса. Наше главное преимущество в том,
 что ваш собеседник или юридическое лицо остается 
конфиденциальным.
***
This bot is for you to learn a language or
 run your own business. Our main advantage
 is that your interlocutor or legal entity
 remains confidential.");
        
        context.Session.Action = "About";
    }

    public async Task Help(ControllerContext context)
    {
        await this.SendMessage(context, @"Agar sizga bot xizmati yoqsa
 va botimiz imkoniyatlarini kengaytirmoqchi 
bo'lsangiz, quyidagi yordam xodimlariga
 murojaat qiling.
***
Если вам нравится сервис бота 
и вы хотите расширить возможности
 нашего бота, обратитесь к следующему
 персоналу службы поддержки.
***
If you like the bot service 
and want to expand the capabilities 
of our bot, please contact the 
following support staff.
+998947774444");
        context.Session.Action = "Help";
    }
    
    
}