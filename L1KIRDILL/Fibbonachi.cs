namespace L1KIRDILL
{
    public static class Fibbonachi
    {
        public static void Print(int kol)
        {
            int summ = 0, ch1 = 0, ch2 = 1;
            Console.Write(summ + " ");
            while (summ <= kol)
            {
                summ = ch1 + ch2;
                if (summ <= kol)
                {
                    Console.Write(summ + " ");
                    ch2 = ch1;
                    ch1 = summ;
                }
            }
            Console.WriteLine();
        }
    }
}
