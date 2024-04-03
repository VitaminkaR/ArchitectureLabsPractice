namespace ArchitectureLabsPractice
{
    public class Program
    {
        static private void Main(string[] args)
        {
            string input = "";

            Console.WriteLine("Первое задание (вывести аргументы):");
            PrintArgs.Print(args);
            Console.WriteLine("Второе задание (високсоные года 1900-2000):");
            LeapYears.WriteLeapYears(1900, 2000);
            Console.WriteLine("Третье задание (числа Фибоначчи):");
            input = Console.ReadLine();
            if (input == "")
                input = "15";
            FibonacciNumbers.PrintFinonacciNumbers(int.Parse(input));
            Console.WriteLine("Четвертое задание (факториал):");
            input = "";
            input = Console.ReadLine();
            if (input == "")
                input = "5";
            Factorial.Fact(int.Parse(input));
            Console.WriteLine("Пятое задание (простые числа через решето Эратосфена):");
            PrimeNumbers.PrintPrimeNumbers(100);
        }
    }
}