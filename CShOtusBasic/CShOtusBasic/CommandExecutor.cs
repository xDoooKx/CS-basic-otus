using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CShOtusBasic
{
    public class CommandExecutor
    {
        public static IReadOnlyCollection<CommandModel> AvailableCommands = new List<CommandModel>() 
        {
            new CommandModel() { Name = "/start", Description = "Стартуем программу с этой команды. Нужна для авторизации пользователя." },
            new CommandModel() { Name = "/help", Description = "Выводим на экран все доступные команды." },
            new CommandModel() { Name = "/info", Description = "Команда выводит на экран системную информацию о самой программе." },
            new CommandModel() { Name = "/echo", Description = "Команда повторяет сообщение пользователя." },
            new CommandModel() { Name = "/clean", Description = "Команда очищает экран консоли." },
            new CommandModel() { Name = "/exit", Description = "Завершие программы." }                        
        };
        public static IReadOnlyCollection<CommandModel> CommandsAvailableWithoutSetName = new List<CommandModel>()
        {
            AvailableCommands.Where(x => x.Name == "/start").Single(),
            AvailableCommands.Where(x => x.Name == "/clean").Single(),
            AvailableCommands.Where(x => x.Name == "/exit").Single()
        };


        public static void ExecuteCommand(string? command)
        {
            if (String.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine();
                Console.WriteLine("Недопустимая команда!");
                Console.WriteLine();
                return;
            }

            string realCommand = command.Split(" ")[0];
            var commandFromList = AvailableCommands.Where(x => x.Name == realCommand).SingleOrDefault(new CommandModel { Name = "FAIL" });
            
            if (!UserModel.IsNameSet && !CommandsAvailableWithoutSetName.Any(x => x.Name == commandFromList.Name))
            {
                Console.WriteLine();
                Console.WriteLine("Для пользования программой нужно начать со старта");
                Console.WriteLine();
                return;
            }
            if (commandFromList == null || commandFromList.Name == "FAIL")
            {
                Console.WriteLine();
                Console.WriteLine($"{UserModel.UserName}, это недоступная команда!");
                Console.WriteLine("Чтобы узнать список команд - напиши /help");
                Console.WriteLine();
                return;
            }
            
            switch (commandFromList.Name)
            {
                case "/start":
                    CommandStart();
                    break;
                case "/help":
                    CommandHelp();
                    break;
                case "/info":
                    CommandInfo();
                    break;
                case "/echo":
                    CommandEcho(command);
                    break;
                case "/clean":
                    CommandClean();
                    break;
                case "/exit":
                    CommandExit();
                    break;
            }
        }


        #region Список всех выполняемых команд
        public static void CommandStart()
        {
            if (UserModel.IsNameSet)
            {
                Console.WriteLine();
                Console.WriteLine("Вижу, что ты уже авторизован :)");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Великолепно! Как я могу к тебе обращаться?");
            Console.Write("Введи своё имя: ");

            var inputName = Console.ReadLine();
            if (UserModel.SetUserName(inputName) != "OK")
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка: неверный формат имени!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Привет, {UserModel.UserName} :)");
            Console.WriteLine($"Для понимания, что тут происходит, можешь запустить команду /help");
            Console.WriteLine();
        }

        public static void CommandHelp()
        {
            Console.WriteLine();
            Console.WriteLine($"{UserModel.UserName}, вот список доступных команд:");
            
            foreach (var item in AvailableCommands)
            {
                Console.WriteLine($"{item.Name} - {item.Description}");
            }

            Console.WriteLine();
        }

        public static void CommandInfo()
        {
            ProjectSettings.PrintAppSettings();
        }        

        public static void CommandEcho(string command)
        {
            string? echoMessage = command.Substring(5).Trim();

            if (String.IsNullOrWhiteSpace(echoMessage)) echoMessage = "ничего :(";

            Console.WriteLine();
            Console.WriteLine($"{UserModel.UserName}, ты написал: {echoMessage}");
            Console.WriteLine();
        }

        public static void CommandClean()
        {
            Console.Clear();
        }

        public static void CommandExit()
        {
            AppState.CloseApp();
        }
        #endregion
    }
}
