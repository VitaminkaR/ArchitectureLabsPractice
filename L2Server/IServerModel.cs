using System.Net.Sockets;

namespace L2Server
{
    internal interface IServerModel
    {
        void CreateServer(string host, int port);
        bool StartServer();
        void ListenClients();
        void HandlerClient(TcpClient client);
        void CloseServer();
        void SendStringClient(TcpClient client, string msg);
        void SendStringBroadcast(string msg);

        void SetViewHandler(Action<string> action);
    }
}
