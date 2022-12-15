using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b, h;

            while (true)
            {
                try
                {
                    Console.Write("Введите начальное значение интервала: ");
                    a = double.Parse(Console.ReadLine());

                    Console.Write("Введите конечное значение интервала: ");
                    b = double.Parse(Console.ReadLine());

                    if (a > b) throw new Exception("Начальное значение интервала не может быть больше конечного!");

                    Console.Write("Введите шаг функции: ");
                    h = double.Parse(Console.ReadLine());

                    if (h == .0) throw new Exception("Введите шаг отличный от нуля!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат введенных данных!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (double i = a; i < b; i += h)
            {
                Console.Write($"x: {i} ");
                try
                {
                    Console.WriteLine($"y: {f(i)}");
                }
                catch
                {
                    Console.WriteLine($"y: не определена в точке x");
                }
            }
        }

        static double f(double x)
        {
            double y = Math.Sqrt((x * x * x) - 1) / Math.Sqrt((x * x) - 1);

            if (double.IsNaN(y)
                || double.IsInfinity(y)
                ) throw new NotFiniteNumberException();

            return y;
           
        }
    }
}
