using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Server
{
    internal interface IController
    {
        void SetView(IView view);
        void SetModel(IServerModel model);
        void ControllerMain();
    }
}
