using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureLabsPractice
{
    public class FibonacciNumbers
    {
        static public void PrintFinonacciNumbers(int count)
        {
            int cnum = 1;
            int pnum = 1;
            Console.Write("0 1 ");
            for (int i = 0; i <= count; i++)
            {
                Console.Write(cnum + " ");
                int a = cnum;
                cnum = cnum + pnum;
                pnum = a;
            }
            Console.WriteLine();
        }
    }
}
