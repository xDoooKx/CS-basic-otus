
namespace CShOtusBasic
{
    public class AppState
    {
        private const string separator = "-----------------------------------------------";

        public static bool IsAppRunning { get; private set; } = true;

        public static void AppInit()
        {
            Console.WriteLine(separator);
            Console.WriteLine("Инициализирую программу...");
            Console.WriteLine(separator);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void CloseApp()
        {
            Console.WriteLine();
            Console.WriteLine(separator);
            Console.WriteLine("Завершаю выполнение программы...");
            Console.WriteLine(separator);
            Console.WriteLine();

            IsAppRunning = false;
        }
    }
}
