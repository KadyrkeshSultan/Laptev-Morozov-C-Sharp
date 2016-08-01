using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Payment
    {
        string fullName;
        double salary;//зарплата
        DateTime date;
        double procentPremium;
        double income;//налог
        int amountofworkDay;
        int amountofDay;
        double ChargedSum;//начисленная сумма
        double WithHoldSum;//удержанная сумма
        public double GetChargedSum()
        {
            ChargedSum = (salary / amountofDay) * amountofworkDay;
            ChargedSum += ChargedSum * (procentPremium / 100);
            return ChargedSum;
        }//Можно
        public double GetWithHoldSum()
        {
            WithHoldSum = GetChargedSum() * ((income / 100) +  0.1);
            return WithHoldSum;
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
