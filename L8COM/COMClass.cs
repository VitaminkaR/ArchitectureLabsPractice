using System;
using System.Runtime.InteropServices;

namespace L8COM
{
    [Guid("37038da0-0b3e-4772-82d8-74cb08762922")]
    public interface ICOMClass
    {
        [DispId(1)]
        int RandInt(int x, int y);
        [DispId(2)]
        double Pow(double x, double y);
        [DispId(3)]
        double Solve(double x, double y, double X, double Y);
    }

    [Guid("d7406f12-4c48-4297-8629-2cf34d724989"),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ICOMEvents
    {

    }

    [ClassInterface(ClassInterfaceType.None),
    Guid("238d4963-c103-4368-ac20-22fe93ad9a61"),
        ComSourceInterfaces(typeof(ICOMEvents)),
        ComVisible(true)]
    public class COMClass : ICOMClass
    {
        public double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public int RandInt(int x, int y)
        {
            return new Random().Next(x, y + 1);
        }

        public double Solve(double x, double y, double X, double Y)
        {
            return (x * y) / (X * Y);
        }
    }
}
