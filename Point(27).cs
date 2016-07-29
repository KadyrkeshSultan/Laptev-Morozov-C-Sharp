using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Point
    {
        private int X;
        private int Y;
        private double p;
        private double phi;
        public double LengthToOXY()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
        public double LengthTo(Point B)
        {
            return Math.Sqrt(Math.Pow(B.X - X, 2) + Math.Pow(B.Y - Y, 2));
        }
        public void TransPolar()
        {
            p = Math.Round(Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)), 2);
            phi = Math.Round(Math.Acos(X / (p)), 2);
            Console.WriteLine("Polar coordinate: P = {0}, Phi = {1}", p, phi);
        }
        public Point()
        {
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Program
    {
        static void Main(string[] argc)
        {
            Point A = new Point(3, 4);
            Point B = new Point(5, 6);
            Console.WriteLine(A.LengthTo(B));
            Console.WriteLine(A.LengthToOXY());
            A.TransPolar();
            
            Console.ReadKey();
        }
    }
}
