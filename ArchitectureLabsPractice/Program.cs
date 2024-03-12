namespace ArchitectureLabsPractice
{
    public class Program
    {
        static private void Main(string[] args)
        {
            Console.WriteLine("Первое задание (вывести аргументы):");
            PrintArgs.Print(args);
            Console.WriteLine("Второе задание (високсоные года 1900-2000):");
            LeapYears.WriteLeapYears(1900, 2000);
            Console.WriteLine("Третье задание (числа Фибоначчи):");
            FibonacciNumbers.PrintFinonacciNumbers(15);
            Console.WriteLine("Четвертое задание (факториал):");
            Factorial.Fact(5);
            Console.WriteLine("Пятое задание (простые числа через решето Эратосфена):");
            PrimeNumbers.PrintPrimeNumbers(100);
        }
    }
}