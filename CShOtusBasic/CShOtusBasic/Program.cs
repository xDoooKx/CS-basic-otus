
namespace CShOtusBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppState.AppInit();

            Console.WriteLine("Привет! :)");
            Console.WriteLine();
            Console.WriteLine("Для старта приложения напиши мне /start");
            Console.WriteLine($"Можно также использовать:");
            
            foreach (var item in CommandExecutor.CommandsAvailableWithoutSetName) Console.WriteLine(item.Name);
            
            Console.WriteLine("Остальные функции будут доступны только после старта");
            Console.WriteLine();

            while (AppState.IsAppRunning)
            {
                var formatLine = UserModel.IsNameSet ? $"Что будем делать дальше, {UserModel.UserName}?" : "Что будем делать дальше?";

                Console.WriteLine(formatLine);
                var inputCommand = Console.ReadLine();
                
                CommandExecutor.ExecuteCommand(inputCommand);
            }            
        }
    }
}
