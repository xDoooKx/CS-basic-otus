using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    public static class ProjectSettingsModel
    {
        public const string AppVersion = "0.01";
        public const string AppAuthor = "Мистер Димончик :)";
        public const string AppCreatedDate = "21.06.2024";


        public static bool IsAppRunning { get; private set; } = true;
        

        public static void AppInit()
        {            
            Console.WriteLine("--------------------------");
            Console.WriteLine("Инициализирую программу...");
            Console.WriteLine("--------------------------");

            CommandModel.InitThis();
            Console.WriteLine("--------------------------");
            
            Console.WriteLine("Готово!");
            Console.WriteLine("--------------------------");            

            Console.WriteLine();            
        }

        public static void AppShutDown()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Завершаю выполнение программы...");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            IsAppRunning = false;
        }

        public static void PrintAppSettings()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"{UserModel.UserName}, вот данные программы:");
            Console.WriteLine($"Версия программы: {AppVersion}");
            Console.WriteLine($"Автор программы: {AppAuthor}");
            Console.WriteLine($"Дата создания программы: {AppCreatedDate}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
        }
    }
}
