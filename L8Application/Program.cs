using L8COM;

namespace L8Application
{
    public class Program
    {
        private static void Main()
        {
            COMClass @class = new COMClass();

            Console.WriteLine("Введите 4 числа: ");
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            double n3 = int.Parse(Console.ReadLine());
            double n4 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Случайноe число в диапозоне n1 и n2: {@class.RandInt((int)n1, (int)n2)}");
            Console.WriteLine($"N1 в степени n2: {@class.Pow(n1, n2)}");
            Console.WriteLine($"Вычисление выражения n1*n2/(n3+n4): {@class.Solve(n1, n2, n3, n4)}");
        }
    }
}