using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using Grpc.Net.Client;

namespace L4Client
{
    class Program
    {
        static private void Main(string[] args)
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

            using var channel = GrpcChannel.ForAddress("http://localhost:5016");
            var client = new Matrix.MatrixClient(channel);

            MatrixRequest mr = new MatrixRequest();
            foreach (var item in inmatrix)
                mr.M.Add(item);
            MatrixReply reply = client.CalculateMatrixAsync(mr).ResponseAsync.Result;

            int k = 0;
            foreach (var item in reply.M)
            {
                if (k % size == 0)
                    Console.WriteLine();
                Console.Write(item + " ");
                k++;
            }

            Console.ReadKey();
        }
    }
}