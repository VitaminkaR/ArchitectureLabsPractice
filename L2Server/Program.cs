namespace L2Server
{
    class Program
    {
        static private void Main()
        {
            IServer server = new Server();
            server.CreateServer("127.0.0.1", 8888);
            server.StartServer();
        }
    }
}