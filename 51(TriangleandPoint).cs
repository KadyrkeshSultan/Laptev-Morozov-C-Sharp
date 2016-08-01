using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
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
    class Triangle
    {
        public double AngleA { get; set; }
        public double AngleB { get; set; }
        public double AngleC { get; set; }

        public double SideAB { get; set; }
        public double SideAC { get; set; }
        public double SideBC { get; set; }
        public double height { get; set; }
        public Triangle(Point A, Point B, Point C)
        {
            double AB = A.LengthTo(B);
            double AC = A.LengthTo(C);
            double BC = B.LengthTo(C);
            if (AB < BC + AC && BC < AC + AB && AC < AB + BC)
            {
                if (Math.Pow(AB, 2) + Math.Pow(AC, 2) == Math.Pow(BC, 2))
                    AngleA = 90;
                else if (Math.Pow(AB, 2) + Math.Pow(BC, 2) == Math.Pow(AC, 2))
                    AngleB = 90;
                else if (Math.Pow(AC, 2) + Math.Pow(BC, 2) == Math.Pow(AB, 2))
                    AngleC = 90;

                SideAB = AB;
                SideAC = AC;
                SideBC = BC;
                Console.WriteLine("Треугольниу существует");
            }
            else
                Console.WriteLine("Такой треугольник не существует!");
        }
        
        public int Type()
        {
            if (AngleA == 90)
                return 1;
            if (AngleB == 90)
                return 2;
            if (AngleC == 90)
                return 3;
            if (SideAB == SideAC && SideAB == SideBC)
                return 4;
            return 5;
        }
        public double Peremetr()
        {
            return SideAB + SideAC + SideBC;
        }
        public void Area()
        {
            double Area;
            double p = Peremetr() / 2;
            switch (Type())
            {
                case 1:
                    Area = SideAB * SideAC / 2;
                    height = (2 * Area) / SideBC;
                    break;
                case 2:
                    Area = SideAB * SideBC / 2;
                    height = (2 * Area) / SideAC;
                    break;
                case 3:
                    Area = SideAC * SideBC / 2;
                    height = (2 * Area) / SideAB;
                    break;
                case 4:
                    Area = (Math.Pow(SideAB, 2) * Math.Sqrt(3)) / 4;
                    height = Math.Sqrt(Math.Pow(SideAB, 2) - Math.Pow(SideAB / 2, 2));
                    break;
                default:
                    Area = Math.Sqrt(p * (p - SideAB) * (p - SideAC) * (p - SideBC));
                    height = (2 * Area) / SideAB;//Maybe false height
                    break;
            }
            Console.WriteLine("Area Triangle = {0}, Height = {1}", Area, height);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle trian = new Triangle(new Point(0, 0), new Point(3, 4), new Point(5, 6));
            Console.WriteLine(trian.Peremetr());
            Console.ReadKey();
        }
    }
}
