namespace L1KIRDILL
{
    public static class Factorial
    {
        public static void Print(int fact)
        {
            int pr = 1;
            for (int i = 1;  i <= fact; i++)
            {
                pr *= i;
            }
            Console.WriteLine(pr);
        }
    }
}
