using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Money
    {
        int par10;
        int par50;
        int par100;
        int par500;
        int par1000;
        
        public double sum;
        public static Money operator +(Money money1, Money money2)
        {
            Money result = new Money();
            result.par10 = money1.par10 + money2.par10;
            result.par50 = money1.par50 + money2.par50;
            result.par100 = money1.par100 + money2.par100;
            result.par500 = money1.par500 + money2.par500;
            result.par1000 = money1.par1000 + money2.par1000;
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
            par10 = 0;
            par50 = 0;
            par100 = 0;
            par500 = 0;
            par1000 = 0;
            sum = 0;
        }
        public Money(int Par10, int Par50, int Par100, int Par500, int Par1000)
        {
            par10 = Par10;
            par50 = Par50;
            par100 = Par100;
            par500 = Par500;
            par1000 = Par1000;
            sum = (par10 * 10) + (par50 * 50) + (par100 * 100) + (par1000 * 1000);
        }
    }
    class Bankomat
    {
        Money bank;
        string idbankomat;
        int NowSumMoney;
        public int MinSum;
        public int MaxSum;
        public void ShowMoney()
        {
            Console.WriteLine("Сумма денег оставшиеся в банкомате состовляет: {0}",bank.sum);
        }
        public void CheckPasswordForLoadMoney()
        {
            Console.WriteLine("Введите пароль для получение доступа к загрузки денег в банкомат:");
            Start:
            string str = Console.ReadLine();
            if (str == "1307")
            {
                Console.WriteLine("Пароль верен. Доступ разрешен!");
                LoadMoney();
            }
            else
            {
                Console.WriteLine("Пароль неверен, повторите!");
                goto Start;
            }
        }
        private void LoadMoney()
        {
            Console.WriteLine("Введите количество загружаемых купюр с номиналом в 10 рублей");
            int Par10 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество загружаемых купюр с номиналом в 50 рублей");
            int Par50 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество загружаемых купюр с номиналом в 100 рублей");
            int Par100 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество загружаемых купюр с номиналом в 500 рублей");
            int Par500 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество загружаемых купюр с номиналом в 1000 рублей");
            int Par1000 = Convert.ToInt32(Console.ReadLine());
            Money LoadBank = new Money(Par10, Par50, Par100, Par500, Par1000);
            bank = bank + LoadBank;
            NowSumMoney = (int)bank.sum;
        }
        public void WithDrawMoney()
        {
            int sum;
            Console.WriteLine("Минимальная/Максимальная сумма которую вы можете снять {0}/{1}", MinSum, MaxSum);
            Console.WriteLine("Какую сумму вы хотите снять?");
            Start2:
            sum = Convert.ToInt32(Console.ReadLine());
            if (sum >= MinSum && sum <= MaxSum)
            {
                NowSumMoney -= sum;
                bank.sum = NowSumMoney;
            }
            else
            {
                Console.WriteLine("Минимальная/Максимальная сумма которую вы можете снять {0}/{1}", MinSum, MaxSum);
                goto Start2;
            }

        }
        public Bankomat(string ID, int NowSum, int min, int max)
        {
            idbankomat = ID;
            if (idbankomat.Contains("1234"))
            {
                int PAR1000 = NowSum / 1000;
                bank = new Money(0, 0, 0, 0, PAR1000);
            }
            else if (idbankomat.Contains("5678"))
            {
                int PAR50 = NowSum / 50;
                bank = new Money(0, PAR50, 0, 0, 0);
            }
            else if (idbankomat.Contains("3456"))
            {
                int PAR100 = NowSum / 100;
                bank = new Money(0, 0, PAR100, 0, 0);
            }
            else if (idbankomat.Contains("1678"))
            {
                int PAR500 = NowSum / 500;
                bank = new Money(0, 0, 0, PAR500, 0);
            }
            else
            {
                int PAR10 = NowSum / 10;
                bank = new Money(PAR10, 0, 0, 0, 0);
            }
            NowSumMoney = NowSum;
            MinSum = min;
            MaxSum = max;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bankomat banks = new Bankomat("0001234", 1000000, 10, 10000);
            banks.CheckPasswordForLoadMoney();
            banks.ShowMoney();
            banks.WithDrawMoney();
            banks.ShowMoney();
            banks.CheckPasswordForLoadMoney();
            banks.ShowMoney();
            Console.ReadKey();
        }
    }
}
