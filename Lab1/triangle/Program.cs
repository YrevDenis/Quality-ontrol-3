using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    const int MAX_SIDE = 500001;
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Ошибка");
            return;
        }

        if (double.TryParse(args[0], out double a) &&
            double.TryParse(args[1], out double b) &&
            double.TryParse(args[2], out double c))
        {
            string result = DetermineTriangleType(a, b, c);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Ошибка");
        }
    }

    static string DetermineTriangleType(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0 || a >= MAX_SIDE || b >= MAX_SIDE || c >= MAX_SIDE)
        {
            return "Ошибка";
        }

        if (a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
            {
                return "Равносторонний";
            }
            else if (a == b || b == c || a == c)
            {
                return "Равнобедренный";
            }
            else
            {
                return "Обычный";
            }
        }
        else
        {
            return "Ошибка";
        }
    }
}
