// See https://aka.ms/new-console-template for more information

using TCB.Aplication.Service;
using TCB.Aplication.Service.Interface;
using Telegram.Bot;

string token="6344298364:AAHi9gGdqWsd23bzNCEuDxMkS2OGDS8uyoc";
TelegramBotClient client = new TelegramBotClient(token);
IAnonymChatService anonymChatService = new AnonymChatService(client);
anonymChatService.Initialize();
Thread.Sleep(-1);