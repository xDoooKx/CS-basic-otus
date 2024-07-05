
namespace CShOtusBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppState.AppInit();

            MyMathModel myMathModel = new MyMathModel();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Инструкция:");
            Console.WriteLine("Для выбора раздела - используйте стрелки на клавиатуре (указатель будет сдвигаться)");
            Console.WriteLine("Чтобы ввести выбранную переменную - поставьте на неё указатель и нажмите Enter или начните вводить данные");
            Console.WriteLine("Чтобы произвести расчет - поставьте указатель на \"Рассчитать\" и нажмите Enter");
            Console.WriteLine("Для выхода - нажмите Escape");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter, чтобы продолжить...");
            Console.ReadLine();


            while (AppState.IsAppRunning)
            {
                myMathModel.StartCalcs();
            }            
        }
    }
}
