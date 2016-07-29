using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Rational
    {
        private int numerator;
        private int denominator;
        public Rational(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public Rational()
        {
        }
        private int Reduce(int a, int b)
        {
            while (b != 0)
            {
                b = a % (a = b);
            }
            return a;
        }
        public static Rational operator +(Rational num1, Rational num2)
        {
            int GCD;
            Rational result = new Rational();
            result.numerator = (num1.numerator * num2.denominator) + (num1.denominator * num2.numerator);
            result.denominator = num1.denominator * num2.denominator;
            GCD = result.Reduce(result.numerator, result.denominator);
            result.numerator /= GCD;
            result.denominator /= GCD;
            return result;
        }
        public static Rational operator -(Rational num1, Rational num2)
        {
            int GCD;
            Rational result = new Rational();
            result.numerator = (num1.numerator * num2.denominator) - (num1.denominator * num2.numerator);
            result.denominator = num1.denominator * num2.denominator;
            GCD = result.Reduce(result.numerator, result.denominator);
            result.numerator /= GCD;
            result.denominator /= GCD;
            return result;
        }
        public static Rational operator *(Rational num1, Rational num2)
        {
            int GCD;
            Rational result = new Rational();
            result.numerator = num1.numerator * num2.numerator;
            result.denominator = num1.denominator * num2.denominator;
            GCD = result.Reduce(result.numerator, result.denominator);
            result.numerator /= GCD;
            result.denominator /= GCD;
            return result;
        }
        public static Rational operator /(Rational num1, Rational num2)
        {
            int GCD;
            Rational result = new Rational();
            result.numerator = num1.numerator * num2.denominator;
            result.denominator = num1.denominator * num2.numerator;
            GCD = result.Reduce(result.numerator, result.denominator);
            result.numerator /= GCD;
            result.denominator /= GCD;
            return result;
        }
        public static bool operator ==(Rational num1, Rational num2)
        {
            double NUM1 = (double)num1.numerator / num1.denominator;
            double NUM2 = (double)num2.numerator / num2.denominator;
            if (NUM1 == NUM2)
                return true;
            else
                return false;
        }
        public static bool operator !=(Rational num1, Rational num2)
        {
            double NUM1 = (double)num1.numerator / num1.denominator;
            double NUM2 = (double)num2.numerator / num2.denominator;
            if (NUM1 != NUM2)
                return true;
            else
                return false;
        }
        public static bool operator <(Rational num1, Rational num2)
        {
            double NUM1 = (double)num1.numerator / num1.denominator;
            double NUM2 = (double)num2.numerator / num2.denominator;
            if (NUM1 < NUM2)
                return true;
            else
                return false;
        }
        public static bool operator >(Rational num1, Rational num2)
        {
            double NUM1 = (double)num1.numerator / num1.denominator;
            double NUM2 = (double)num2.numerator / num2.denominator;
            if (NUM1 > NUM2)
                return true;
            else
                return false;
        }
        public void Show()
        {
            Console.WriteLine("{0}/{1}", numerator,denominator);
        }
    }
    class Program
    {
        static void Main(string[] argc)
        {
            Rational num1 = new Rational(1,4);
            Rational num2 = new Rational(1, 5);
            
            Console.ReadKey();
        }
    }
}
