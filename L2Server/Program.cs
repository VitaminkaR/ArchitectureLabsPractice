namespace L2Server
{
    class Program
    {
        static private void Main()
        {
            IServerModel serverModel = new ServerModel();
            IView view = new View();
            IController controller = new Controller();

            controller.SetView(view);
            controller.SetModel(serverModel);
            controller.ControllerMain();
        }
    }
}