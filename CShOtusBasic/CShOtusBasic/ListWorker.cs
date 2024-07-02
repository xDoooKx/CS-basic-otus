using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    public class ListWorker
    {
        private static int cycleLenght = 1000000;


        List<int> list = new List<int>(cycleLenght);
        ArrayList listArray = new ArrayList(cycleLenght);
        LinkedList<int> listLinked = new LinkedList<int>();
        
        
        public void WorkWithLists()
        {            
            Stopwatch sw = new Stopwatch();



            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Укажи количество элементов в каждом массиве (оставь пустым, чтобы было 1млн.): ");
            string? getCommand = Console.ReadLine();

            if (!CheckUserCommandForInt(getCommand, true)) return;
            FillTheArrays(getCommand);



            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Введи, какой элемент найти: ");
            getCommand = Console.ReadLine();

            if (!CheckUserCommandForInt(getCommand, checkForArrayCapacity: cycleLenght)) return;            
            SearchInArrays(getCommand);


            Console.WriteLine();
            Console.WriteLine();
            Console.Write("На сколько нужно делить без остатка: ");
            getCommand = Console.ReadLine();

            if (!CheckUserCommandForInt(getCommand)) return;
            DivWithoutRem(getCommand);
        }

        private void FillTheArrays(string getCommand)
        {
            Random random = new Random();
            Stopwatch sw = new Stopwatch();
            
            if (!String.IsNullOrWhiteSpace(getCommand) && int.Parse(getCommand) > 0) cycleLenght = int.Parse(getCommand);

            sw.Start();
            for (int i = 1; i <= cycleLenght; i++)
            {
                list.Add(random.Next());
            }
            sw.Stop();
            Console.WriteLine($"Заполнил List<int> {cycleLenght} элементами за: {sw}");
            sw.Reset();

            sw.Start();
            for (int i = 1; i <= cycleLenght; i++)
            {
                listArray.Add(random.Next());
            }
            sw.Stop();
            Console.WriteLine($"Заполнил ArrayList {cycleLenght} элементами за: {sw}");
            sw.Reset();

            sw.Start();
            for (int i = 1; i <= cycleLenght; i++)
            {
                listLinked.AddLast(random.Next());
            }
            sw.Stop();
            Console.WriteLine($"Заполнил LinkedList<int> {cycleLenght} элементами за: {sw}");
            sw.Reset();

            Console.WriteLine("--------------------------");
            Console.WriteLine("Закончил заполнение");
            Console.WriteLine("--------------------------");
        }

        private void SearchInArrays(string getCommand)
        {
            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == int.Parse(getCommand))
                {
                    sw.Stop();
                    Console.WriteLine("Поиск по массиву list занял: " + sw);
                    sw.Reset();

                    break;
                }
            }

            sw.Start();
            for (int i = 0; i < listArray.Count; i++)
            {
                if (i == int.Parse(getCommand))
                {
                    sw.Stop();
                    Console.WriteLine("Поиск по массиву listArray занял: " + sw);
                    sw.Reset();

                    break;
                }
            }

            sw.Start();
            for (int i = 0; i < listLinked.Count; i++)
            {
                if (i == int.Parse(getCommand))
                {
                    sw.Stop();
                    Console.WriteLine("Поиск по массиву listLinked занял: " + sw);
                    sw.Reset();

                    break;
                }
            }
        }

        private void DivWithoutRem(string getCommand)
        {
            Stopwatch sw = new Stopwatch();            

            StringBuilder sbArrayData = new StringBuilder();
            int arrayDataCounter = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Прохожу List<int> через for:");
            sw.Start();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % int.Parse(getCommand) == 0)
                {
                    sbArrayData.Append($"{list[i]},");
                    arrayDataCounter++;
                }
            }
            sw.Stop();
            Console.WriteLine("Поиск чисел, деленных без остатка в массиве List<int>, занял: " + sw);
            Console.WriteLine("Таких чисел: " + arrayDataCounter);
            Console.WriteLine("Вот они: " + sbArrayData.ToString());
            sw.Reset();
            sbArrayData.Clear();
            arrayDataCounter = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Прохожу ArrayList через for:");
            sw.Start();
            for (int i = 0; i < listArray.Count; i++)
            {
                if ((int)listArray[i] % int.Parse(getCommand) == 0)
                {
                    sbArrayData.Append($"{list[i]},");
                    arrayDataCounter++;
                }
            }
            sw.Stop();
            Console.WriteLine("Поиск чисел, деленных без остатка в массиве ArrayList, занял: " + sw);
            Console.WriteLine("Таких чисел: " + arrayDataCounter);
            Console.WriteLine("Вот они: " + sbArrayData.ToString());
            sw.Reset();
            sbArrayData.Clear();
            arrayDataCounter = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Прохожу LinkedList через foreach:");
            sw.Start();
            foreach (var item in listLinked)
            {
                if (item % int.Parse(getCommand) == 0)
                {
                    sbArrayData.Append($"{item},");
                    arrayDataCounter++;
                }
            }
            sw.Stop();
            Console.WriteLine("Поиск чисел, деленных без остатка в массиве LinkedList, занял: " + sw);
            Console.WriteLine("Таких чисел: " + arrayDataCounter);
            Console.WriteLine("Вот они: " + sbArrayData.ToString());
            sw.Reset();
            sbArrayData.Clear();
            arrayDataCounter = 0;


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Бонус!\r\nПрохожу LinkedList через for:");
            sw.Start();
            for (LinkedListNode<int> node = listLinked.First; node != null; node = node.Next)
            {
                if (node.Value % int.Parse(getCommand) == 0)
                {
                    sbArrayData.Append($"{node.Value},");
                    arrayDataCounter++;
                }
            }
            sw.Stop();
            Console.WriteLine("Поиск чисел, деленных без остатка в массиве LinkedList, занял: " + sw);
            Console.WriteLine("Таких чисел: " + arrayDataCounter);
            Console.WriteLine("Вот они: " + sbArrayData.ToString());
            sw.Reset();
            sbArrayData.Clear();
            arrayDataCounter = 0;
        }

        private bool CheckUserCommandForInt(string? getCommand, bool isAllowEmpty = false, int checkForArrayCapacity = -1)
        {
            if (!getCommand.All(char.IsDigit))
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Ошибка ввода команды: вводимая строка не может быть отличной от цифр!");
                Console.WriteLine("---------------------------");
                return false;
            }

            if (String.IsNullOrWhiteSpace(getCommand) && !isAllowEmpty)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Ошибка ввода команды!");
                Console.WriteLine("---------------------------");
                return false;
            }

            int _parsedInt = -1;
            Int32.TryParse(getCommand, out _parsedInt);
            if ( _parsedInt == -1)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Ошибка ввода команды: неверное значение!");
                Console.WriteLine("---------------------------");
                return false;
            }

            if (checkForArrayCapacity > 0)
            {
                if (Int32.Parse(getCommand) < 0 || Int32.Parse(getCommand) > cycleLenght)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Ошибка ввода команды: значение не в диапазоне массива!");
                    Console.WriteLine("---------------------------");
                    return false;
                }
            }                     

            return true;
        }
    }
}
