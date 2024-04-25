using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace L2Server
{
    class Client
    {
        public TcpClient Cl;
        public string Nickname;
    }

    internal class ServerModel : IServerModel
    {
        public const int PACKET_SIZE = 1024;

        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public IPEndPoint IPEndPoint { get; set; }

        private TcpListener m_TcpListener;

        private bool m_IsActive;

        private List<Client> m_Clients;

        private Action<string> m_ModelChangedAction;

        public bool StartServer()
        {
            try
            {
                m_TcpListener.Start();
                m_IsActive = true;
                Thread thread = new Thread(new ThreadStart(ListenClients));
                thread.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void CreateServer(string host, int port)
        {
            IPAddress = IPAddress.Parse(host);
            Port = port;
            IPEndPoint = new IPEndPoint(IPAddress, Port);
            m_TcpListener = new TcpListener(IPEndPoint);
            m_Clients = new List<Client>();
        }

        public void ListenClients()
        {
            while (m_IsActive)
            {
                TcpClient tcpClient = m_TcpListener.AcceptTcpClient();

                Thread thread = new Thread(new ParameterizedThreadStart((object? obj) => HandlerClient(tcpClient)));
                thread.Start();
                m_Clients.Add(new Client() { Cl = tcpClient });
                m_ModelChangedAction("New client connected");
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
                    m_ModelChangedAction($"Received: {data}");
                }
                catch (Exception)
                {
                    for (int i = 0; i < m_Clients.Count; i++)
                    {
                        if (m_Clients[i].Cl == client)
                        {
                            m_Clients.Remove(m_Clients[i]);

                            string _data = "u";
                            for (int j = 0; j < m_Clients.Count; j++)
                            {
                                _data += "\n" + m_Clients[j].Nickname;
                            }
                            SendStringBroadcast(_data);

                            break;
                        }
                    }
                    break;
                }

                if (data[0] == 'n')
                {
                    Regex regex = new Regex("n");
                    data = regex.Replace(data, "", 1);
                    nickname = data;

                    for (int i = 0; i < m_Clients.Count; i++)
                    {
                        if (m_Clients[i].Cl == client)
                        {
                            m_Clients[i].Nickname = nickname;

                            string _data = "u";
                            for (int j = 0; j < m_Clients.Count; j++)
                            {
                                _data += "\n" + m_Clients[j].Nickname;
                            }
                            SendStringBroadcast(_data);

                            break;
                        }
                    }
                    Thread.Sleep(500);

                    SendStringBroadcast($"m{nickname} подключился к чату");
                }
                if (data[0] == 'm')
                {
                    Regex regex = new Regex("m");
                    data = regex.Replace(data, "m" + nickname + ": ", 1);
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
                m_Clients[i].Cl.GetStream().Write(bytes, 0, bytes.Length);
            }
        }

        public void SendStringBroadcast(string msg, TcpClient clientSender)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            for (int i = 0; i < m_Clients.Count; i++)
            {
                if (m_Clients[i].Cl != clientSender)
                    m_Clients[i].Cl.GetStream().Write(bytes, 0, bytes.Length);
            }
        }

        public void SetViewHandler(Action<string> action)
        {
            m_ModelChangedAction = action;
        }
    }
}
