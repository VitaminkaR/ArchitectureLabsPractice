using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace L2Server
{
    internal class Server : IServer
    {
        public const int PACKET_SIZE = 1024;

        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public IPEndPoint IPEndPoint { get; set; }

        private TcpListener m_TcpListener;

        private bool m_IsActive;

        private List<TcpClient> m_Clients;

        public void StartServer()
        {
            m_TcpListener.Start();
            Console.WriteLine($"Server started on {IPEndPoint}");
            m_IsActive = true;
            ListenClients();
        }

        public void CreateServer(string host, int port)
        {
            IPAddress = IPAddress.Parse(host);
            Port = port;
            IPEndPoint = new IPEndPoint(IPAddress, Port);
            m_TcpListener = new TcpListener(IPEndPoint);
            m_Clients = new List<TcpClient>();
        }

        public void ListenClients()
        {
            while (m_IsActive)
            {
                TcpClient tcpClient = m_TcpListener.AcceptTcpClient();

                Thread thread = new Thread(new ParameterizedThreadStart((object? obj) => HandlerClient(tcpClient)));
                thread.Start();
                m_Clients.Add(tcpClient);
                Console.WriteLine("New client connected");
            }
        }

        public void HandlerClient(TcpClient client)
        {
            string nickname = "";
            NetworkStream stream = client.GetStream();

            while (m_IsActive)
            {
                byte[] bytes = new byte[PACKET_SIZE];
                string data = "";

                try
                {
                    int i = stream.Read(bytes, 0, bytes.Length);
                    data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine($"Received: {data}");
                }
                catch (Exception)
                {
                    m_Clients.Remove(client);
                    break;
                }

                if (data[0] == 'n')
                {
                    Regex regex = new Regex("n");
                    data = regex.Replace(data, "", 1);
                    nickname = data;
                    SendStringBroadcast($"{nickname} подключился к чату");
                }
                if (data[0] == 'm')
                {
                    Regex regex = new Regex("m");
                    data = regex.Replace(data, nickname + ": ", 1);
                    SendStringBroadcast(data);
                }

                Thread.Sleep(20);
            }
        }

        public void CloseServer()
        {
            m_IsActive = false;
            m_TcpListener.Stop();
            m_TcpListener.Dispose();
            Console.WriteLine("Server closed");
        }

        public void SendStringClient(TcpClient client, string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            client.GetStream().Write(bytes, 0, bytes.Length);
        }

        public void SendStringBroadcast(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            for (int i = 0; i < m_Clients.Count; i++)
            {
                m_Clients[i].GetStream().Write(bytes, 0, bytes.Length);
            }
        }

        public void SendStringBroadcast(string msg, TcpClient clientSender)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            for (int i = 0; i < m_Clients.Count; i++)
            {
                if (m_Clients[i] != clientSender)
                    m_Clients[i].GetStream().Write(bytes, 0, bytes.Length);
            }
        }
    }
}
