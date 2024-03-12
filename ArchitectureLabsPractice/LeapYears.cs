using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureLabsPractice
{
    public class LeapYears
    {
        static public void WriteLeapYears(int startYear, int endYear)
        {
            for (int i = startYear; i <= endYear; i++)
            {
                Console.Write($"Год {i}   ");
                Console.WriteLine(((i % 4 == 0 && i % 100 != 0) || i % 400 == 0) ? "високосный" : "не високосный");
            }
        }
    }
}
