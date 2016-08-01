using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
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
        public double GetDoubleMoney()
        {
            return ruble + (kop / 100);
        }
    }
    class Payment
    {
        string fullName;
        double salary;//зарплата
        DateTime date;
        double procentPremium;
        double income;//налог
        int amountofworkDay;
        int amountofDay;
        Money ChargedSum;//начисленная сумма
        Money WithHoldSum;//удержанная сумма
        public double GetChargedSum()
        {
            ChargedSum = new Money((salary / amountofDay) * amountofworkDay);
            ChargedSum += ChargedSum * (procentPremium / 100);
            return ChargedSum.GetDoubleMoney();
        }//Можно
        public double GetWithHoldSum()
        {
            WithHoldSum = new Money(GetChargedSum() * ((income / 100) + 0.1));
            return WithHoldSum.GetDoubleMoney();
        }//сделать
        public double GetSalary()
        {
            return GetChargedSum() - GetWithHoldSum();
        }//эти методы
        public int GetExperience()
        {
            return DateTime.Now.Year - date.Year;
        }//private
        public void Show()
        {
            Console.WriteLine("ФИО: {0} Оклад: {1} Количество отработаных дней: {2} Год поступление на работу: {3} ", fullName, salary, amountofworkDay, date.Year);
            Console.WriteLine("Премия(процент): {0} Налог: {1} Начисленная сумма: {2} Удерженная сумма: {3} ", procentPremium, income, GetChargedSum(), GetWithHoldSum());
            Console.WriteLine("Сумма полученная на руки: {0} Стаж работы: {1}", GetSalary(), GetExperience());
        }
        public Payment(string Fullname, double Salary, int AmountOfDay, int AmountOfWorkDay, DateTime Date, double Procent, double Income)
        {
            fullName = Fullname;
            salary = Salary;
            amountofDay = AmountOfDay;
            amountofworkDay = AmountOfWorkDay;
            date = Date;
            procentPremium = Procent;
            income = Income;
        }
    }   
    class Program
    {
        static void Main(string[] args)
        {
            Payment pay = new Payment("Kadyrkesh", 100000, 30, 20, new DateTime(2012, 08, 15), 10, 10);
            pay.Show();
            Console.ReadKey();
        }
    }
}
