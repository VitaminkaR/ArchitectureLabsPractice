namespace ArchitectureLabsPractice
{
    public class PrintArgs
    {
        static public void Print(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
                Console.Write(args[i] + " ");
            Console.WriteLine();
        }
    }
}
