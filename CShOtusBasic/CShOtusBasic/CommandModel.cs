using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    public class CommandModel
    {
        private static string? lastCommand;        

        
        public static List<Commands> AvailableCommands { get; private set; } = new List<Commands>();
        public static List<Commands> CommandsAvailableWithoutSetName { get; private set; } = new List<Commands>();


        public static void InitThis() 
        {
            string currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string jsonPath = Path.Combine(currentDir, "AvailableCommands.json");

            string jsonReadString = File.ReadAllText(jsonPath);
            var jsonDoc = JsonDocument.Parse(jsonReadString);
            var commandList = jsonDoc.RootElement.GetProperty("objectList").Deserialize<List<Commands>>();
            
            foreach (var item in commandList)
            {
                AvailableCommands.Add(item);
                if (item.IsWithoutAuth) CommandsAvailableWithoutSetName.Add(item);
            }

            Console.WriteLine("Закончил инициализацию CommandModel...");
        }

        public static void ExecuteCommand(string? command)
        {
            string realCommand = command.Split(" ")[0];
            var commandFromList = AvailableCommands.Where(x => x.Name == realCommand).SingleOrDefault(new Commands { Name = "FAIL" });
            
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

            Type? getClassType = Type.GetType("CShOtusBasic.CommandModel");            
            if (getClassType != null && commandFromList != null)
            {
                MethodInfo? getTheMethod = getClassType.GetMethod(commandFromList.CommandName, BindingFlags.Static | BindingFlags.Public);

                if (getTheMethod != null)
                {
                    object[] methodParams = new object[] { command };

                    if (commandFromList.HasParams) getTheMethod.Invoke(null, methodParams);
                    else getTheMethod.Invoke(null, null);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"УППППССССССССССССССССССС...");
                    Console.WriteLine($"Что-то пошло не так - этого не должно было произойти, {UserModel.UserName} :(");
                    Console.WriteLine();
                }
            }

            //Тут вариант со свитч, но он не так легко масштабируется (хочется описать все команды в одном месте) и слишком простой :D
            //switch (realCommand)
            //{
            //    case "/start":
            //        CommandStart();
            //        break;
            //    case "/help":
            //        CommandHelp();
            //        break;
            //    case "/info":
            //        CommandInfo();
            //        break;
            //    case "/echo":
            //        CommandEcho(command);
            //        break;
            //    case "/clean":
            //        CommandClean();
            //        break;
            //    case "/exit":
            //        CommandExit();
            //        break;
            //}
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

            lastCommand = Console.ReadLine();
            if (UserModel.SetUserName(lastCommand) != "OK")
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка: неверный формат имени!");
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
            ProjectSettingsModel.PrintAppSettings();
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
            ProjectSettingsModel.AppShutDown();
        }
        #endregion


        public class Commands
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string CommandName { get; set; }
            public bool HasParams { get; set; } = false;
            public bool IsWithoutAuth { get; set; } = false;
        }
    }
}
