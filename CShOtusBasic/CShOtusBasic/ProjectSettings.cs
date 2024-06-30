
namespace CShOtusBasic
{
    public static class ProjectSettings
    {
        public const string AppVersion = "0.03";
        public const string AppAuthor = "Мистер Димончик :)";
        public const string AppCreatedDate = "21.06.2024";                

        public static void PrintAppSettings()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Данные программы:");
            Console.WriteLine($"Версия программы: {AppVersion}");
            Console.WriteLine($"Автор программы: {AppAuthor}");
            Console.WriteLine($"Дата создания программы: {AppCreatedDate}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
        }
    }
}
