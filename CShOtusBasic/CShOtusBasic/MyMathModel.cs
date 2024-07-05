

using System.Collections;
using System.Text;

namespace CShOtusBasic
{
    public class MyMathModel
    {
        private bool isEnteringData;
        private QuadraticEquationModel QEM;
        private StringBuilder consoleOutput = new StringBuilder();        
        private Dictionary<int, string> menuNavigation = new Dictionary<int, string>();
        private Dictionary<int, string> userCommandData = new Dictionary<int, string>();        


        public MyMathModel()
        {
            menuNavigation.Add(1, "a");
            menuNavigation.Add(2, "b");
            menuNavigation.Add(3, "c");
            menuNavigation.Add(4, "calc");
        }


        public void StartCalcs()
        {            
            QEM = new QuadraticEquationModel();
            isEnteringData = true;
            var _currentPointer = 1;

            userCommandData.Clear();
            consoleOutput.Clear();
            
            PrintToConsole(_currentPointer);

            while (isEnteringData)
            {                
                var _getKey = Console.ReadKey();

                if (_getKey.Key == ConsoleKey.UpArrow) 
                {                    
                    if (--_currentPointer <= 0) _currentPointer = menuNavigation.Count;             
                }
                else if (_getKey.Key == ConsoleKey.DownArrow)
                {                    
                    if (++_currentPointer > menuNavigation.Count) _currentPointer = 1;                                     
                }
                else if (_getKey.Key == ConsoleKey.Enter)
                {
                    if (_currentPointer == 4)
                    {
                        isEnteringData = false;
                        break;
                    }

                    EnterTheData(_currentPointer);
                }
                else if (_getKey.Key == ConsoleKey.Escape)
                {                    
                    AppState.ChangeAppState();                    
                }
                else
                {
                    if (_currentPointer != 4) EnterTheData(_currentPointer);
                }

                PrintToConsole(_currentPointer);                
            }

            Console.Clear();
            Console.WriteLine();            
            double? _discrim = QEM.GetDiscrim(); 
            if (_discrim < 0)
            {
                ExceptionHandler myEx = new ExceptionHandler("Нет корней уравнения: дискриминант < 0");

                myEx.Data.Add("a", QEM.inputedA);
                myEx.Data.Add("b", QEM.inputedB);
                myEx.Data.Add("c", QEM.inputedC);
                myEx.Data.Add("Discremenant", _discrim);

                myEx.FormatData(myEx.Message, ExceptionHandler.Severity.Warning, myEx.Data);
            }
            else
            {
                Console.WriteLine();
                var _res = QEM.GetResults();
                Console.WriteLine(_res);                
            }

            Console.WriteLine();
            Console.WriteLine("Нажми enter, чтобы продлжить, или 2 - для выхода");
            Console.Write("> ");

            if (Console.ReadLine() == "2") AppState.ChangeAppState();
        }

        private void EnterTheData(int pointer)
        {
            PrintToConsole(pointer, true);
            var _getCommand = Console.ReadLine();
            if (String.IsNullOrEmpty(_getCommand)) _getCommand = "0";

            switch (pointer)
            {
                case 1: QEM.inputedA = _getCommand; break;
                case 2: QEM.inputedB = _getCommand; break;
                case 3: QEM.inputedC = _getCommand; break;
            }

            if (userCommandData.Where(x => x.Key == pointer).Count() != 0) userCommandData.Remove(pointer);

            userCommandData.Add(pointer, _getCommand);
        }

        private void PrintToConsole(int pointer, bool enteringData = false)
        {                  
            string _a = "a", _b = "b", _c = "c";
            string rowA = "", rowB = "", rowC = "", rowD = "Рассчитать";

            if (QEM.inputedA != "NaN") _a = QEM.inputedA;
            if (QEM.inputedB != "NaN") _b = QEM.inputedB;
            if (QEM.inputedC != "NaN") _c = QEM.inputedC;

            switch (pointer)
            {
                case 1:
                    rowA = ">a: ";
                    rowB = "b: ";
                    rowC = "c: ";                    
                    rowD = "Рассчитать";                    
                    break;
                case 2:
                    rowA = "a: ";
                    rowB = ">b: ";
                    rowC = "c: ";
                    rowD = "Рассчитать";
                    break;
                case 3:
                    rowA = "a: ";
                    rowB = "b: ";
                    rowC = ">c: ";
                    rowD = "Рассчитать";
                    break;
                case 4:
                    rowA = "a: ";
                    rowB = "b: ";
                    rowC = "c: ";
                    rowD = ">Рассчитать";
                    break;
            }

            Console.Clear();
            consoleOutput.Clear();
            consoleOutput.Append($"\r\nСчитаем квадратное уравнение:");
            consoleOutput.Append($"\r\n{_a} * x^2 + {_b} * x + {_c} = 0");
            consoleOutput.Append($"\r\n{rowA}{(QEM.inputedA != "NaN" ? QEM.inputedA : "")}");
            consoleOutput.Append($"\r\n{rowB}{(QEM.inputedB != "NaN" ? QEM.inputedB : "")}");
            consoleOutput.Append($"\r\n{rowC}{(QEM.inputedC != "NaN" ? QEM.inputedC : "")}");
            consoleOutput.Append($"\r\n{rowD}");
            if (enteringData)
            {
                consoleOutput.Append($"\r\nЗначение для {menuNavigation[pointer]}: ");
                Console.Write(consoleOutput.ToString());
            }
            else Console.WriteLine(consoleOutput.ToString());

        }



        #region Старый вариант через последовательный ввод
        //public void Begin() 
        //{
        //    userCommandData.Clear();
        //    consoleOutput.Clear();

        //    Console.Clear();
        //    consoleOutput.Clear();            
        //    consoleOutput.Append($"\r\nСчитаем квадратное уравнение:");
        //    consoleOutput.Append($"\r\na * x^2 + b * x + c = 0");
        //    consoleOutput.Append($"\r\n> a: ");            
        //    consoleOutput.Append($"\r\nb: ");
        //    consoleOutput.Append($"\r\nc: ");
        //    Console.WriteLine(consoleOutput.ToString());
        //    var _getCommandA = Console.ReadLine();
        //    userCommandData.Add("a", _getCommandA);

        //    ConsoleKey keywoard = Console.ReadKey().Key;

        //    Console.Clear();
        //    consoleOutput.Clear();
        //    consoleOutput.Append($"\r\nСчитаем квадратное уравнение:");
        //    consoleOutput.Append($"\r\n{_getCommandA} * x^2 + b * x + c = 0");
        //    consoleOutput.Append($"\r\na: {_getCommandA}");
        //    consoleOutput.Append($"\r\n> b: ");
        //    consoleOutput.Append($"\r\nc: ");
        //    Console.WriteLine(consoleOutput.ToString());
        //    var _getCommandB = Console.ReadLine();
        //    userCommandData.Add("b", _getCommandB);

        //    Console.Clear();
        //    consoleOutput.Clear();
        //    consoleOutput.Append($"\r\nСчитаем квадратное уравнение:");
        //    consoleOutput.Append($"\r\n{_getCommandA} * x^2 + {_getCommandB} * x + c = 0");
        //    consoleOutput.Append($"\r\na: {_getCommandA}");
        //    consoleOutput.Append($"\r\nb: {_getCommandB}");
        //    consoleOutput.Append($"\r\n> c: ");
        //    Console.WriteLine(consoleOutput.ToString());
        //    var _getCommandC = Console.ReadLine();
        //    userCommandData.Add("c", _getCommandC);

        //    Console.Clear();
        //    consoleOutput.Clear();
        //    consoleOutput.Append($"\r\nСчитаем квадратное уравнение:");
        //    consoleOutput.Append($"\r\n{_getCommandA} * x^2 + {_getCommandB} * x + {_getCommandC} = 0");
        //    consoleOutput.Append($"\r\na: {_getCommandA}");
        //    consoleOutput.Append($"\r\nb: {_getCommandB}");
        //    consoleOutput.Append($"\r\nc: {_getCommandC}");
        //    Console.WriteLine(consoleOutput.ToString());            

        //    try
        //    {
        //        a = int.Parse(_getCommandA);
        //        b = int.Parse(_getCommandB);
        //        c = int.Parse(_getCommandC);
        //    }
        //    catch
        //    {
        //        ExceptionHandler myEx = new ExceptionHandler("Ошибка ввода данных!");

        //        myEx.Data.Add("a", userCommandData["a"]);
        //        myEx.Data.Add("b", userCommandData["b"]);
        //        myEx.Data.Add("c", userCommandData["c"]);

        //        myEx.FormatData(myEx.Message, ExceptionHandler.Severity.Error, myEx.Data);

        //        Console.WriteLine();
        //        Console.Write("Нажмите enter для продолжения...");
        //        Console.ReadLine();
        //        return;                

        //        //Исключение не выбрасываем, чтобы всё не упало
        //        //throw myEx;
        //    }

        //    Console.WriteLine();
        //    double _discrim = (b * b) - (4 * a * c);
        //    //Console.WriteLine($"Дискриминант уравнения: {_discrim}");
        //    if (_discrim < 0 ) 
        //    {
        //        ExceptionHandler myEx = new ExceptionHandler("Нет корней уравнения: дискриминант < 0");

        //        myEx.Data.Add("a", userCommandData["a"]);
        //        myEx.Data.Add("b", userCommandData["b"]);
        //        myEx.Data.Add("c", userCommandData["c"]);
        //        myEx.Data.Add("Discremenant", _discrim);

        //        myEx.FormatData(myEx.Message, ExceptionHandler.Severity.Warning, myEx.Data);
        //    }
        //    else if (_discrim == 0) 
        //    {
        //        var _x1 = ((-1) * b + Math.Sqrt(_discrim)) / (2 * a);
        //        Console.WriteLine($"Решение: x = {_x1}");
        //    }
        //    else if (_discrim > 0)
        //    {
        //        var _x1 = ((-1) * b + Math.Sqrt(_discrim)) / (2 * a);
        //        var _x2 = ((-1) * b - Math.Sqrt(_discrim)) / (2 * a);
        //        Console.WriteLine($"Решение: x1 = {_x1}, x2 = {_x2}");
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine("Нажми enter или 1, чтобы продлжить, или 2 - для выхода");
        //    Console.Write("> ");

        //    if (Console.ReadLine() == "2") AppState.ChangeAppState();

        //}
        #endregion
    }
}
