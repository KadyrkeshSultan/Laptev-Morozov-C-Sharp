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
        string date;//dd.mm.yy
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
        public double GetCostGoods()
        {
            return cost * count;
        }
        public void Show()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", name, date, cost, count, NumberInvoice);
        }
        public Goods(string Name, string Date, double Cost, int Count, string numberinvoice)
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
            Goods good = new Goods("Computer", "22.12.15", 104000.2 , 2, "1234567");
            good.EditCount(3);
            Console.WriteLine(good.GetCostGoods());
            good.Show();
            Console.ReadKey();
        }
    }
}
