using Messages;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

while (true)
{
    Console.Write("Введите размер матрицы: ");
    int size = int.Parse(Console.ReadLine());

    int[,] inmatrix = new int[size, size];
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            inmatrix[i, j] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
    }

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            Console.Write(inmatrix[i, j] + " ");
        }
        Console.WriteLine();
    }


    TcpClient tcpClient = new TcpClient();
    tcpClient.Connect("127.0.0.1", 9999);
    NetworkStream stream = tcpClient.GetStream();





    List<int> ar = new List<int>();
    XmlMsgRequestCalculateMatrix mr = new XmlMsgRequestCalculateMatrix(ar);
    foreach (var item in inmatrix)
        ar.Add(item);

    string msg = mr.GetXmlString();
    byte[] requestData = Encoding.UTF8.GetBytes(msg);
    stream.Write(requestData);



    XmlMsgReplyCalculateMatrix reply = new XmlMsgReplyCalculateMatrix();
    byte[] buffer = new byte[4096];
    int bsize = stream.Read(buffer, 0, 4096);
    reply.GetXmlObject(Encoding.UTF8.GetString(buffer));

    int k = 0;
    Console.Write("\nMin element: " + reply.MinNumber);
    foreach (var item in reply.Matrix)
    {
        if (k % size == 0)
            Console.WriteLine();
        Console.Write(item + " ");
        k++;
    }


    Console.ReadKey();
    Console.WriteLine('\n');
}



