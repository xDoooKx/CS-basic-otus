using System.Collections;
using System.Drawing;


namespace CShOtusBasic
{
    public class ExceptionHandler: Exception
    {
        public enum Severity { Warning, Error }


        public ExceptionHandler(string message) : base(message) { }


        public void FormatData(string message, Severity severity, IDictionary data)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            switch (severity)
            {
                case Severity.Warning:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;                    
                    break;
                case Severity.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
            }


            Console.WriteLine("");
            Console.WriteLine($"---------------------------------------------------");
            Console.WriteLine($"Ошибка: {message}");
            Console.WriteLine($"---------------------------------------------------");
            Console.WriteLine($"Информация из блока Data:");

            foreach (DictionaryEntry item in data)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
