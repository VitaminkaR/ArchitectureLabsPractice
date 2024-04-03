using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureLabsPractice
{
    public class Factorial
    {
        static public void Fact(int num)
        {
            int res = 1;
            for (int i = 1; i <= num; i++)
                res *= i;
            Console.WriteLine(res);
        }
    }
}
