using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Goods
    {
        string name;
        DateTime date;//dd.mm.yy
        Money cost;
        int count;
        string NumberInvoice;
        int yearStorage;
        public void EditCost(double Cost)
        {
            cost = cost + new Money(Cost);
        }
        public void EditCount(int Count)
        {
            count += Count;
        }
        public double GetAllCostGoods()
        {
            return cost.GetDouble() * (double)count;
        }
        public void Show()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", name, date, cost, count, NumberInvoice);
        }
        public int GetTermStorage()
        {
            int days = (DateTime.Now.DayOfYear - date.DayOfYear) + (365 * (DateTime.Now.Year - (date.Year + yearStorage)));
            if (days <= 0)
                days = 0;
            return days;
        }
        public double GetValue()
        {
            double sum;
            sum = (0.01 * cost.GetDouble()) * (double)GetTermStorage();
            if (cost.GetDouble() <= sum)
                return 0;
            return cost.GetDouble() - sum;
        }
        public Goods(string Name, DateTime Date, Money Cost, int Count, string numberinvoice, int yearStorage)
        {
            name = Name;
            date = Date;
            cost = Cost;
            count = Count;
            NumberInvoice = numberinvoice;
            this.yearStorage = yearStorage;
        }
    }
    class Money
    {
        private double ruble;
        private double kop;
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
        public static Money operator /(Money A, double B)
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
        public static Money operator *(Money A, double B)
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
        public double GetDouble()
        {
            return ruble + (kop / 100);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Goods good = new Goods("Asus", new DateTime(2015, 07, 10), new Money(100000), 10, "1234", 1);
            Console.WriteLine(good.GetTermStorage());
            good.Show();
            Console.WriteLine(good.GetValue());
            Console.WriteLine(good.GetAllCostGoods());
            Console.ReadKey();
        }
    }
}
