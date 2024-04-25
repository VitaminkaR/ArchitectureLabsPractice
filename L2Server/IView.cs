using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Server
{
    internal interface IView
    {
        void ShowText(string txt);
        void ModelChanged(string info);
    }
}
