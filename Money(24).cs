using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Money
    {
        private int ruble;
        private int kop;
        public Money()
        {
        }
        public Money(double sum)
        {
            ruble = (int)sum;
            kop = (int)((sum - ruble) * 100);
        }
        public static Money operator +(Money A, Money B)
        {
            Money result = new Money();
            result.ruble = A.ruble + B.ruble;
            result.kop = A.kop + B.kop;
            if (result.kop >= 100)
            {
                result.ruble += 1;
                result.kop %= 100;
            }
            return result;

        }
        public static Money operator -(Money A, Money B)
        {
            Money result = new Money();
            result.ruble = A.ruble - B.ruble;
            if (A.kop < B.kop)
            {
                result.ruble -= 1;
                result.kop = B.kop - A.kop;
            }
            else
                result.kop = A.kop - B.kop;
            return result;
        }
        public static Money operator /(Money A, Money B)
        {
            Money result = new Money();
            double division = ((double)A.ruble + ((double)A.kop / 100)) / ((double)B.ruble + ((double)B.kop / 100));
            result.ruble = (int)division;
            result.kop = (int)((division - result.ruble) * 100);
            return result;
        }
        public static Money operator /(Money A, int B)
        {
            Money result = new Money();
            double division = ((double)A.ruble + ((double)A.kop / 100)) / B;
            result.ruble = (int)division;
            result.kop = (int)((division - result.ruble) * 100);
            return result;
        }
        public static Money operator *(Money A, Money B)
        {
            Money result = new Money();
            double mult = ((double)A.ruble + ((double)A.kop / 100)) * ((double)(B.ruble) + ((double)B.kop / 100));
            result.ruble = (int)mult;
            result.kop = (int)((mult - result.ruble) * 100);
            return result;
        }
        public static Money operator *(Money A, int B)
        {
            Money result = new Money();
            double mult = B * ((double)A.ruble + ((double)A.kop / 100));
            result.ruble = (int)mult;
            result.kop = (int)((mult - result.ruble) * 100);
            return result;
        }
        public static bool operator <=(Money A, Money B)
        {
            if (((double)A.ruble + ((double)A.kop / 100)) <= ((double)B.ruble + ((double)B.kop / 100)))
                return true;
            else
                return false;
        }
        public static bool operator >=(Money A, Money B)
        {
            if (((double)A.ruble + ((double)A.kop / 100)) >= ((double)B.ruble + ((double)B.kop / 100)))
                return true;
            else
                return false;
        }
        public void Show()
        {
            Console.WriteLine("Ruble = {0}, Kop = {1}", ruble, kop);
        }
    }
    class Program
    {
        static void Main(string[] argc)
        {
            Money moneyA = new Money(12.4);
            Money moneyB = new Money(1.5);
            
            Console.ReadKey();
        }
    }
}
