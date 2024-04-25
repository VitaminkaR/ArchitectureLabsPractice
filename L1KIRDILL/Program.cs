namespace L1KIRDILL
{
    class Program
    {
        static private void Main(string[] args)
        {
            new PrintArgs().Print(args);
            PrintYears.Print();
            string str = Console.ReadLine(); 
            Fibbonachi.Print(int.Parse(str));
            string fact = Console.ReadLine();
            Factorial.Print(int.Parse(fact));
            string era = Console.ReadLine();
            Eratosfen.Print(int.Parse(era));
        }
    }
}