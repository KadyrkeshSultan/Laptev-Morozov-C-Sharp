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
        double cost;
        int count;
        string NumberInvoice;
        public void EditCost(double Cost)
        {
            cost += Cost;
        }
        public void EditCount(int Count)
        {
            count += Count;
        }
        public double GetAllCostGoods()
        {
            return cost * count;
        }
        public void Show()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", name, date, cost, count, NumberInvoice);
        }
        public int GetTermStorage()
        {
            int days = (DateTime.Now.DayOfYear - date.DayOfYear) + (365 * (DateTime.Now.Year - date.Year));
            return days;
        }
        public Goods(string Name, DateTime Date, double Cost, int Count, string numberinvoice)
        {
            name = Name;
            date = Date;
            cost = Cost;
            count = Count;
            NumberInvoice = numberinvoice;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Goods good = new Goods("Asus", new DateTime(2015, 07, 30), 100000, 10, "1234");
            Console.WriteLine(good.GetTermStorage());
            good.Show();
            Console.WriteLine(good.GetAllCostGoods());
            Console.ReadKey();
        }
    }
}
