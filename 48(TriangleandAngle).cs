using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Angle
    {
        public double VALUE { get; set; }
        bool isGrad = true;

        public bool IsGrad
        {
            get { return isGrad; }
            set { isGrad = value; }
        }
        public double Radians
        {
            get { return VALUE; }
            set { VALUE = value; IsGrad = false; }
        }
        public double Gradus
        {
            get { return VALUE; }
            set
            {
                if (value > 360)
                {
                    VALUE = value - 360;
                    while (VALUE > 360)
                    {
                        VALUE -= 360;
                    }
                }
                else VALUE = value;
            }
        }

        public double RadToGrad()
        {
            if (isGrad)
            {
                Console.WriteLine("Невозможно перевести в градусы");
                return 0;
            }
            else
            {
                isGrad = true;
                return VALUE * 180 / 3.14;
            }

        }

        public double GradToRad()
        {
            if (isGrad)
            {
                isGrad = false;
                return VALUE * 3.14 / 180;
            }
            else
            {
                Console.WriteLine("Невозможно перевести в радианны");
                return 0;
            }
        }

        public static double operator +(Angle obj1, Angle obj2)
        {
            double Result = 0;
            if (obj1.isGrad == true && obj2.isGrad == true)
            {
                if ((obj1.Gradus + obj2.Gradus) > 360)
                {
                    Result = Math.Abs(360 - (obj1.Gradus + obj2.Gradus));
                }
                else Result = obj1.Gradus + obj2.Gradus;
            }
            else
            {
                Console.WriteLine("Для сложения углов, для начала переведите их в градусы");
            }

            return Result;
        }

        public static double operator -(Angle obj1, Angle obj2)
        {
            double Result = 0;
            if (obj1.isGrad == true && obj2.isGrad == true)
            {
                if ((obj1.Gradus - obj2.Gradus) < 0)
                {
                    Result = 360 - Math.Abs((obj1.Gradus - obj2.Gradus));
                }
                else Result = obj1.Gradus - obj2.Gradus;
            }
            else
            {
                Console.WriteLine("Для вычитания углов, для начала переведите их в градусы");
            }

            return Result;
        }
        public Angle(double value)
        {
            VALUE = value;
        }
    }
    class Triangle
    {
        Angle AngleA;
        Angle AngleB;
        Angle AngleC;

        public double SideAB { get; set; }
        public double SideAC { get; set; }
        public double SideBC { get; set; }
        public double height { get; set; }
        public Triangle(double AB, double BC, double AC)
        {
            if (AB < BC + AC && BC < AC + AB && AC < AB + BC)
            {
                if (Math.Pow(AB, 2) + Math.Pow(AC, 2) == Math.Pow(BC, 2))
                    AngleA = new Angle(90);
                else if (Math.Pow(AB, 2) + Math.Pow(BC, 2) == Math.Pow(AC, 2))
                    AngleB = new Angle(90);
                else if (Math.Pow(AC, 2) + Math.Pow(BC, 2) == Math.Pow(AB, 2))
                    AngleC = new Angle(90);

                SideAB = AB;
                SideAC = AC;
                SideBC = BC;
                Console.WriteLine("Òàêîé òðåóãîëüíèê ñóùåñòâóåò");
            }
            else
                Console.WriteLine("Òàêîãî òðåóãîëüíèêà ÍÅ ñóùåñòâóåò!");
        }
        public int Type()
        {
            if (AngleA.VALUE == 90)
                return 1;
            if (AngleB.VALUE == 90)
                return 2;
            if (AngleC.VALUE == 90)
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
            Triangle trian = new Triangle(3, 4, 5);
            trian.GetType();
            Console.ReadKey();
        }
    }
}
