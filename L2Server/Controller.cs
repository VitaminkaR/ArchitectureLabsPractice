using System;

namespace L2Server
{
    internal class Controller : IController
    {
        IServerModel m_Model;
        IView m_View;

        public void ControllerMain()
        {
            m_View.ShowText("Введите IP: ");
            string? ipInput = Console.ReadLine();
            if (ipInput == null || ipInput == "")
                ipInput = "127.0.0.1";

            m_View.ShowText("Введите port: ");
            string? portInput = Console.ReadLine();
            if (portInput == null || portInput == "")
                portInput = "8888";

            m_Model.CreateServer(ipInput, int.Parse(portInput));
            if (m_Model.StartServer())
                m_View.ShowText("Server started");

            m_Model.SetViewHandler(m_View.ModelChanged);
        }

        public void SetModel(IServerModel model) => m_Model = model;

        public void SetView(IView view) => m_View = view;
    }
}
