namespace L1KIRDILL
{
    public static class Eratosfen
    {
        public static void Print(int num)
        {
            int[] list = new int[num];
            for (int k = 0; k < num; k++)
                list[k] = k + 1;
            int i = 2;
            while (i <= num)
            {
                if (list[i - 1] != 0)
                {
                    int j = 2 * i;
                    while (j <= num)
                    {
                        list[j - 1] = 0;
                        j = j + i;
                    }
                }
                i++;
            }
            for (int k = 0; k < num; k++)
                Console.Write(list[k] != 0 ? (list[k] + " ") : "");
        }
    }

}
