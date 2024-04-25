namespace L1KIRDILL
{
    public static class PrintYears
    {
        public static void Print()
        {
            for (int i = 1900; i <= 2000; i++)
            {
                if ((i % 4 == 0) && (i % 100 != 0) || (i % 400 == 0))
                {
                    Console.WriteLine(i + "  " + "Високосный");
                }
                else
                {
                    Console.WriteLine(i + "  " + "Не високосный");
                }
            }
        }
    }
}
