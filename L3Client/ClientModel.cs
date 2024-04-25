using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace L3Client
{
    class ClientModel : IClientModel
    {
        public const int PACKET_SIZE = 1024;

        private string m_UserName;
        private string m_IP;

        private TcpClient m_TcpClient;

        private Action<string, int> m_ReceiveMsg;

        public void Connect()
        {
            m_TcpClient = new TcpClient();
            m_TcpClient.Connect(m_IP, 8888);

            Thread thread = new Thread(new ParameterizedThreadStart((object? obj) => Handler()));
            thread.Start();

            SendMessage("n" + m_UserName);
        }

        private void Handler()
        {
            NetworkStream stream = m_TcpClient.GetStream();
            while (true)
            {
                byte[] bytes = new byte[PACKET_SIZE];
                string data = "";

                int i = stream.Read(bytes, 0, bytes.Length);
                data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);

                if (data[0] == 'm')
                {
                    Regex regex = new Regex("m");
                    data = regex.Replace(data, "", 1);
                    m_ReceiveMsg(data, 0);
                }
                if (data[0] == 'u')
                {
                    Regex regex = new Regex("u");
                    data = regex.Replace(data, "", 1);
                    m_ReceiveMsg(data, 1);
                }

                Thread.Sleep(20);
            }
        }

        public void SetIP(string ip) => m_IP = ip;

        public void SetName(string name) => m_UserName = name;

        public void SendMessage(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            m_TcpClient.GetStream().Write(bytes, 0, bytes.Length);
        }

        public void SetReceiveMsgEvent(Action<string, int> handle) => m_ReceiveMsg = handle;
    }
}
