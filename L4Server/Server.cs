using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Messages;
using System.Drawing;

namespace L4Server
{
    internal class Server
    {
        TcpListener tcpListener;

        public void StartServer(string ip, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(ip), port);
            tcpListener.Start();

            new Thread(new ThreadStart(Handler)).Start();
        }

        void Handler()
        {
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                NetworkStream stream = tcpClient.GetStream();

                byte[] buffer = new byte[4096];
                int bsize = stream.Read(buffer, 0, 4096);

                string msg = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Получено сообщение: \n{msg}\n");

                CallingFunction(msg, stream);
            }
        }

        void CallingFunction(string msg, NetworkStream stream)
        {
            string method = XmlMsg.GetMethod(msg);

            #region CallFunction
            if (method == "CalculateMatrix")
            {
                XmlMsgRequestCalculateMatrix xmrcm = new XmlMsgRequestCalculateMatrix();
                xmrcm.GetXmlObject(msg);
                XmlMsgReplyCalculateMatrix reply = Functions.CalculateMatrixFunction.CalculateMatrix(xmrcm);
                string rmsg = reply.GetXmlString();
                stream.Write(Encoding.UTF8.GetBytes(rmsg));
            }
            #endregion
        }
    }
}
