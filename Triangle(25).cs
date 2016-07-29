using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Triangle
    {
        public double AngleA { get; set; }
        public double AngleB { get; set; }
        public double AngleC { get; set; }

        public double SideAB { get; set; }
        public double SideAC { get; set; }
        public double SideBC { get; set; }
        public double height { get; set; }
        public Triangle(double AB, double BC, double AC)
        {
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
                Console.WriteLine("Такой треугольник существует");
            }
            else
                Console.WriteLine("Такого треугольника НЕ существует!");
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
                case 2 :
                    Area = SideAB * SideBC / 2;
                    height = (2 * Area) / SideAC;
                    break;
                case 3:
                    Area = SideAC * SideBC / 2;
                    height = (2 * Area) / SideAB;
                    break;
                case 4:
                    Area = (Math.Pow(SideAB, 2) * Math.Sqrt(3)) / 4;
                    height = Math.Sqrt(Math.Pow(SideAB,2) - Math.Pow(SideAB/2, 2));
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
        static void Main(string[] argc)
        {
            Triangle triangle = new Triangle(6, 3, 4);
            Console.WriteLine(triangle.Peremetr());
            triangle.Area();
            Console.ReadKey();
        }
    }
}
