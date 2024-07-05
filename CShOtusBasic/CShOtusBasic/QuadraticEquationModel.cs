using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    public class QuadraticEquationModel
    {
        private int a;
        private int b;
        private int c;
        private double discrim;
        private bool isABCParsed = false;


        public string inputedA { get; set; } = "NaN";
        public string inputedB { get; set; } = "NaN";
        public string inputedC { get; set; } = "NaN";        


        public void TryParseData()
        {            
            try
            {
                a = int.Parse(this.inputedA);
                b = int.Parse(this.inputedB);
                c = int.Parse(this.inputedC);
            }
            catch (OverflowException)
            {
                ExceptionHandler myEx = new ExceptionHandler("Значение выходит за границы допустимого Int32!");

                myEx.Data.Add("a", this.inputedA);
                myEx.Data.Add("b", this.inputedB);
                myEx.Data.Add("c", this.inputedC);

                myEx.FormatData(myEx.Message, ExceptionHandler.Severity.Error, myEx.Data);

                return;

                //Исключение не выбрасываем, чтобы всё не упало
                //throw myEx;
            }
            catch
            {
                ExceptionHandler myEx = new ExceptionHandler("Ошибка ввода данных!");

                myEx.Data.Add("a", this.inputedA);
                myEx.Data.Add("b", this.inputedB);
                myEx.Data.Add("c", this.inputedC);

                myEx.FormatData(myEx.Message, ExceptionHandler.Severity.Error, myEx.Data);

                return;

                //Исключение не выбрасываем, чтобы всё не упало
                //throw myEx;
            }

            isABCParsed = true;
        }

        public double? GetDiscrim()
        {
            if (!isABCParsed) TryParseData();            

            return discrim = (this.b * this.b) - (4 * this.a * this.c);
        }

        public string GetResults()
        {
            if (!isABCParsed) return "";

            if (discrim == 0)
            {
                var _x1 = ((-1) * b + Math.Sqrt(discrim)) / (2 * a);
                return $"Решение: x = {_x1}";
            }
            else
            {
                var _x1 = ((-1) * b + Math.Sqrt(discrim)) / (2 * a);
                var _x2 = ((-1) * b - Math.Sqrt(discrim)) / (2 * a);
                return $"Решение: x1 = {_x1}, x2 = {_x2}";
            }
        }
    }
}
