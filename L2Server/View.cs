using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Server
{
    internal class View : IView
    {
        public void ModelChanged(string info)
        {
            ShowText(info);
        }

        public void ShowText(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
