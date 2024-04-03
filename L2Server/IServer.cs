using System.Net.Sockets;

namespace L2Server
{
    internal interface IServer
    {
        void CreateServer(string host, int port);
        void StartServer();
        void ListenClients();
        void HandlerClient(TcpClient client);
        void CloseServer();
        void SendStringClient(TcpClient client, string msg);
        void SendStringBroadcast(string msg);
    }
}
