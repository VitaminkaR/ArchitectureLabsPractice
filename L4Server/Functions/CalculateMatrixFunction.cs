using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4Server.Functions
{
    public static class CalculateMatrixFunction
    {
        static public XmlMsgReplyCalculateMatrix CalculateMatrix(XmlMsgRequestCalculateMatrix request)
        {
            XmlMsgReplyCalculateMatrix reply = new XmlMsgReplyCalculateMatrix();

            int size = (int)Math.Sqrt(request.Matrix.Count);
            int[,] ar = new int[size, size];
            int min = request.Matrix.Min();
            int di = 0, dj = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ar[i, j] = request.Matrix[i * size + j];
                    if (ar[i, j] == min)
                    {
                        di = i;
                        dj = j;
                    }
                }
            }
            while (true)
            {
                if (di <= 0 || dj <= 0)
                    break;
                di--;
                dj--;
            }
            int mincolumn = dj;
            while (true)
            {
                if (di >= size || dj >= size)
                    break;

                ar[di, dj] = 0;
                di++;
                dj++;
            }
            int cdi = 0, cdj = 0;
            bool mul = false;
            while (true)
            {
                if (!mul && (ar[cdi, cdj] == 0 || (cdj < mincolumn)))
                    mul = true;

                if (mul)
                    ar[cdi, cdj] *= ar[cdi, cdj];

                cdi++;
                if (cdi >= size)
                {
                    cdj++;
                    cdi = 0;
                    mul = false;
                }
                if (cdj >= size)
                    break;
            }

            reply.Matrix = new List<int>();
            foreach (var item in ar)
                reply.Matrix.Add(item);
            reply.MinNumber = min;

            return reply;
        }
    }
}
