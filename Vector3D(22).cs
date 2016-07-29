using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    class Vector3D
    {
        Vector a;
        Vector b;
        public void Add()
        {
            int x = a.X + b.X;
            int y = a.Y + b.Y;
            int z = a.Z + b.Z;
            Console.WriteLine("Vector (X: {0} Y: {1} Z: {2})", x,y,z);
        }
        public void Sub()
        {
            int x = a.X - b.X;
            int y = a.Y - b.Y;
            int z = a.Z - b.Z;
            Console.WriteLine("Vector (X: {0} Y: {1} Z: {2})", x, y, z);
        }
        public void Mul()
        {
            int mul = (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
            Console.WriteLine("—кал€рное произвидение векторов = {0}", mul);
        }
        public void MulScalar(int lamda)
        {
            a.X = a.X * lamda;
            a.Y = a.Y * lamda;
            a.Z = a.Z * lamda;
            b.X = b.X * lamda;
            b.Y = b.Y * lamda;
            b.Z = b.Z * lamda;
            Console.WriteLine("Vector a * lamda = ({0}; {1}; {2})", a.X, a.Y, a.Z);
            Console.WriteLine("Vector b * lamda = ({0}; {1}; {2})", b.X, b.Y, b.Z);
        }
        public void Length()
        {
            double lengthA = Math.Sqrt(Math.Pow(a.X,2) + Math.Pow(a.Y,2) + Math.Pow(a.Z,2));
            double lengthB = Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2) + Math.Pow(b.Z, 2));
            Console.WriteLine("ƒлина вектора a = {0}", lengthA);
            Console.WriteLine("ƒлина вектора a = {0}", lengthB);
        }
        public Vector3D(Vector a, Vector b)
        {
            this.a = a;
            this.b = b;
        }
    }
    class Program
    {
        static void Main(string[] argc)
        {
            Vector a = new Vector(1,2,3);
            Vector b = new Vector(4, 5, 6);
            Vector3D ab = new Vector3D(a, b);
            ab.Length();
            Console.ReadKey();
        }
    }
}
