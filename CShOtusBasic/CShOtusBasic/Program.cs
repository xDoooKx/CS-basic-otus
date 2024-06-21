namespace CShOtusBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProjectSettingsModel.AppInit();

            Console.WriteLine("Привет! :)");
            Console.WriteLine();
            Console.WriteLine("Для старта приложения напиши мне /start");
            Console.WriteLine($"Можно также использовать:");
            
            foreach (var item in CommandModel.CommandsAvailableWithoutSetName) Console.WriteLine(item.Name);
            
            Console.WriteLine("Остальные функции будут доступны только после старта");
            Console.WriteLine();

            while (ProjectSettingsModel.IsAppRunning)
            {
                var formatLine = UserModel.IsNameSet ? $"Что будем делать дальше, {UserModel.UserName}?" : "Что будем делать дальше?";

                Console.WriteLine(formatLine);
                var inputCommand = Console.ReadLine();
                
                CommandModel.ExecuteCommand(inputCommand);
            }            
        }
    }
}
