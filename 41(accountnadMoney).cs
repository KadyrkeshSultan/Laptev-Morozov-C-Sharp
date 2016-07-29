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
        public double Show()
        {
            return ruble + (kop / 100);
        }
    }
    class Account
    {
        string firstName;
        string NumberScore;
        double prosent;
        Money money;
        public void BackToName(string Family)
        {
            firstName = Family;
        }
        public void RemoveSum(Money money2)
        {
            money = money - money2;
        }
        public void PutMoneyToScore(Money money2)
        {
            money = money + money2;
        }
        public void AssessmentOfProsent(double Prosent)
        {
            money = money + (money * (Prosent / 100));
        }
        public void TranslateToDollar()
        {
            money *= 341;
        }
        public void TranslateToEuro()
        {
            money *= 423;
        }
        public void GetStringSum()
        {
            Console.Write("Сумма счета: ");
            Console.WriteLine(Convert.ToString(money.Show()));
        }
        public void ShowScore()
        {
            Console.WriteLine("Владелец счета : {0}, номер счета : {1}, проценты начисление : {2}, сумма на счету : {3}",
               firstName, NumberScore, prosent, money.Show());
        }
        public Account(string Name, string Number, double Prosent, Money money2)
        {
            firstName = Name;
            NumberScore = Number;
            prosent = Prosent;
            money = money2;
            Console.WriteLine("Открыт новый счет!");
            Console.WriteLine("Владелец счета : {0}, номер счета : {1}, проценты начисление : {2}, сумма на счету : {3}",
                firstName, NumberScore, prosent, money.Show());
        }
    }
    class Bank
    {
        public Bank()
        {

            Random rand = new Random();
            Console.WriteLine("Вы можете открыть свой банковский счет");
            Console.WriteLine("Введите фамилию лица на которого будет открыт счет");
            string firstName = Console.ReadLine();
            string NumberScore = Convert.ToString(rand.Next(100000, 999999));
            Console.WriteLine("Введите сумму на зачисление на ваш счет");
            double sum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите проценты начисление");
            double prosent = Convert.ToDouble(Console.ReadLine());
            Account account = new Account(firstName, NumberScore, prosent, new Money(sum));
        Start:
            Console.WriteLine("Что хотите сделать?");
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1. Сменить Владельца счета\n2. Снять некоторую сумму\n3. Положить деньги на счет");
            Console.WriteLine("\n4. Начислить проценты\n5. Перевести в доллары\n6. Перевести в Евро\n7. Показать данные о счете");
            int r = Convert.ToInt32(Console.ReadLine());
            switch (r)
            {
                case 1:
                    Console.WriteLine("Введите нового Владельца");
                    account.BackToName(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Какую сумму вы хотите снять?(Введите)");
                    account.RemoveSum(new Money(Convert.ToDouble(Console.ReadLine())));
                    break;
                case 3:
                    Console.WriteLine("Какую сумму вы хотите положить?(Введите)");
                    account.PutMoneyToScore(new Money(Convert.ToDouble(Console.ReadLine())));
                    break;
                case 4:
                    Console.WriteLine("Введите проценты которые вы хотите начислить");
                    account.AssessmentOfProsent(Convert.ToDouble(Console.ReadLine()));
                    break;
                case 5:
                    account.TranslateToDollar();
                    break;
                case 6:
                    account.TranslateToEuro();
                    break;
                default:
                    account.ShowScore();
                    break;
            }
            goto Start;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Console.ReadKey();
        }
    }
}
