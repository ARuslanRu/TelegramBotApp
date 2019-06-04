using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotApp.Models;

namespace TelegramBotApp.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly IBotButtonRepository _repository;

        public UpdateService(IBotService botService, IBotButtonRepository repo)
        {
            _botService = botService;
            _repository = repo;
        }

        public async Task Update(Update update)
        {
            if (update == null) return;

            switch (update.Type)
            {
                case UpdateType.Message:
                    //...
                    await MessageUpdate(update.Message);
                    break;
                case UpdateType.CallbackQuery:
                    //...
                    await CallbackUpdate(update.CallbackQuery);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Действие при получение протого соообщения, типа UpdateType.Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        async Task MessageUpdate(Message message)
        {
            if (message.Type == MessageType.Text)
            {
                switch (message.Text.Split(' ').First())
                {
                    case "/inline":

                        var inlineKeyboardMain = new InlineKeyboardMarkup(new[]
                        {
                            new [] // Первая строка
                            {
                                InlineKeyboardButton.WithCallbackData("Основное меню","0")
                            }
                        });

                        await _botService.Client.SendTextMessageAsync(
                            message.Chat.Id,
                            "Основное меню",
                            replyMarkup: inlineKeyboardMain);

                        break;



                    default:
                        const string usage = @"
Usage:
/inline   - send inline keyboard";

                        await _botService.Client.SendTextMessageAsync(
                            message.Chat.Id,
                            usage,
                            replyMarkup: new ReplyKeyboardRemove());
                        break;
                }
            }
            else if (message.Type == MessageType.Photo)
            {
                // Download Photo
                var fileId = message.Photo.LastOrDefault()?.FileId;
                var file = await _botService.Client.GetFileAsync(fileId);

                var filename = file.FileId + "." + file.FilePath.Split('.').Last();

                using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                {
                    await _botService.Client.DownloadFileAsync(file.FilePath, saveImageStream);
                }

                await _botService.Client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку, типа UpdateType.CallbackQuery
        /// </summary>
        /// <param name="callbackQuery"></param>
        /// <returns></returns>
        async Task CallbackUpdate(CallbackQuery callbackQuery)
        {
            if (callbackQuery == null) return;

            //формирование инлайн клавиатуры
            if (callbackQuery.Data == "0")
            {
                var row = _repository.BotButtons.Where(x => x.ParentId == 0).OrderBy(x => x.Row).ThenBy(x => x.Column).GroupBy(x => x.Row).ToList();

                var inlineKeyboard = new List<List<InlineKeyboardButton>>();
                foreach (var item in row)
                {
                    var listRowButtons = new List<InlineKeyboardButton>();
                    foreach (var i in item)
                    {
                        listRowButtons.Add(InlineKeyboardButton.WithCallbackData($"{i.ButtonName}", i.Id.ToString()));
                    }
                    inlineKeyboard.Add(listRowButtons);
                }

                var inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboard);
                await _botService.Client.EditMessageTextAsync(
                    callbackQuery.Message.Chat.Id,
                    callbackQuery.Message.MessageId,
                    "Основное меню",
                    replyMarkup: inlineKeyboardMarkup);
            }
            else
            {
                int id = 0;
                Int32.TryParse(callbackQuery.Data, out id);

                var row = _repository.BotButtons.Where(x => x.ParentId == id).OrderBy(x => x.Row).ThenBy(x => x.Column).GroupBy(x => x.Row).ToList();

                var inlineKeyboard = new List<List<InlineKeyboardButton>>();
                foreach (var item in row)
                {
                    var listRowButtons = new List<InlineKeyboardButton>();
                    foreach (var i in item)
                    {
                        listRowButtons.Add(InlineKeyboardButton.WithCallbackData($"{i.ButtonName}", i.Id.ToString()));
                    }
                    inlineKeyboard.Add(listRowButtons);
                }

                var parentId = _repository.BotButtons.Where(x => x.Id == id).First().ParentId;

                BotButton backButton = new BotButton();

                //Проверка для возврата в основное меню
                if (parentId != 0)
                {
                    backButton = _repository.BotButtons.Where(x => x.Id == parentId).First();
                }
                else
                {
                    backButton = new BotButton { Id = 0, ParentId = 0, ButtonName = "Оснвоное меню" };
                }

                inlineKeyboard.Add(new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData($"<< Назад в {backButton.ButtonName}", backButton.Id.ToString())
                });

                var inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboard);
                await _botService.Client.EditMessageTextAsync(
                    callbackQuery.Message.Chat.Id,
                    callbackQuery.Message.MessageId,
                    _repository.BotButtons.Where(x => x.Id == id).First().ButtonName,
                    replyMarkup: inlineKeyboardMarkup);
            }
        }

    }
}
