using System;

namespace L1KIRDILL
{
    internal class PrintArgs
    {
        public void Print(string[] args) 
        {
            for (int i = 0; i < args.Length; i++) 
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
