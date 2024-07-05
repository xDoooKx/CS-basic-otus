
using System.Text;

namespace CShOtusBasic
{
    public static class ProjectSettings
    {
        public const string AppVersion = "А0.03";
        public const string AppAuthor = "Мистер Димончик :)";
        public const string AppCreatedDate = "05.07.2024";                
        public const string AppCurrentDescription = "Третья домашка";                

        public static string GetAppSettings()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("\r\n-----------------------------------------------");
            sb.Append($"\r\nДанные программы:");
            sb.Append($"\r\nВерсия программы: {AppVersion}");
            sb.Append($"\r\nАвтор программы: {AppAuthor}");
            sb.Append($"\r\nДата создания программы: {AppCreatedDate}");
            sb.Append($"\r\nОписание текущего билда: {AppCurrentDescription}");
            sb.Append("\r\n-----------------------------------------------");  
            
            return sb.ToString();
        }

        public static void PrintAppSettingsInConsole()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Данные программы:");
            Console.WriteLine($"Версия программы: {AppVersion}");
            Console.WriteLine($"Автор программы: {AppAuthor}");
            Console.WriteLine($"Дата создания программы: {AppCreatedDate}");
            Console.WriteLine($"Описание текущего билда: {AppCurrentDescription}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
        }
    }
}
