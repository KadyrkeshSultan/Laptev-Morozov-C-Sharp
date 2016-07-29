using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Money
    {
        int par1;
        int par2;
        int par5;
        int par10;
        int par50;
        int par100;
        int par500;
        int par1000;
        int par5000;
        int kopeck1;
        int kopeck5;
        int kopeck10;
        int kopeck50;
        public double sum;
        public static Money operator +(Money money1, Money money2)
        {
            Money result = new Money();
            result.par1 = money1.par1 + money2.par1;
            result.par2 = money1.par2 + money2.par2;
            result.par5 = money1.par5 + money2.par5;
            result.par10 = money1.par10 + money2.par10;
            result.par50 = money1.par50 + money2.par50;
            result.par100 = money1.par100 + money2.par100;
            result.par500 = money1.par500 + money2.par500;
            result.par1000 = money1.par1000 + money2.par1000;
            result.par5000 = money1.par5000 + money2.par5000;
            result.kopeck1 = money1.kopeck1 + money2.kopeck1;
            result.kopeck5 = money1.kopeck5 + money2.kopeck5;
            result.kopeck10 = money1.kopeck10 + money2.kopeck10;
            result.kopeck50 = money1.kopeck50 + money2.kopeck50;
            result.sum = money1.sum + money2.sum;
            return result;
        }
        public static Money operator -(Money money1, Money money2)
        {
            Money result = new Money();
            if (money1.sum >= money2.sum)
                result.sum = money1.sum - money2.sum;
            else
                result.sum = money2.sum - money1.sum;
            return result;
        }
        public static Money operator /(Money money1, Money money2)
        {
            Money result = new Money();
            if (money1.sum >= money2.sum)
                result.sum = money1.sum / money2.sum;
            else
                result.sum = money2.sum / money1.sum;
            return result;
        }
        public static Money operator /(Money money1, double money2)
        {
            Money result = new Money();
            if (money1.sum >= money2)
                result.sum = money1.sum / money2;
            else
                result.sum = money2 / money1.sum;
            return result;
        }
        public static Money operator *(Money money1, double money2)
        {
            Money result = new Money();
            result.sum = money1.sum * money2;
            return result;
        }
        public static bool operator >(Money money1, Money money2)
        {
            if (money1.sum > money2.sum)
                return true;
            else
                return false;
        }
        public static bool operator <(Money money1, Money money2)
        {
            if (money1.sum < money2.sum)
                return true;
            else
                return false;
        }
        public Money()
        {
            par1 = 0;
            par2 = 0;
            par5 = 0;
            par10 = 0;
            par50 = 0;
            par100 = 0;
            par500 = 0;
            par1000 = 0;
            par5000 = 0;
            kopeck1 = 0;
            kopeck5 = 0;
            kopeck10 = 0;
            kopeck50 = 0;
            sum = 0;
        }
        public Money(int Par1, int Par2, int Par5, int Par10, int Par50, int Par100, int Par500, int Par1000,int Par5000, int Kopeck1, int Kopeck5, int Kopeck10, int Kopeck50)
        {
            par1 = Par1;
            par2 = Par2;
            par5 = Par5;
            par10 = Par10;
            par50 = Par50;
            par100 = Par100;
            par500 = Par500;
            par1000 = Par1000;
            par5000 = Par5000;
            kopeck1 = Kopeck1;
            kopeck5 = Kopeck5;
            kopeck10 = Kopeck10;
            kopeck50 = Kopeck50;
            sum = (par5000 * 5000) + (par1000 * 1000) + (par500 * 500) + (par100 * 100) + (par50 * 50) + (par10 * 10);
            sum = sum + (par5 * 5) + (par2 * 2) + (par1 * 1) + (((double)kopeck1 * 1) / 100) + (((double)kopeck5 * 5) / 100);
            sum = sum + (((double)kopeck10 * 10) / 100) + (((double)kopeck50 * 50) / 100);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Money money = new Money(14, 0, 0, 0, 0, 2, 0, 4, 1, 0, 0, 1, 0);
            Money money2 = money * 2;
            Console.WriteLine(money2.sum);
            if (money < money2)
                Console.WriteLine("money < money2 ");
            Console.ReadKey();
        }
    }
}
