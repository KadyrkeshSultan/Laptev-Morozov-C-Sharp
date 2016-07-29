using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Account
    {
        string firstName;
        string NumberScore;
        double prosent;
        double sum;
        public void BackToName(string Family)
        {
            firstName = Family;
        }
        public void RemoveSum(double sum)
        {
            this.sum -= sum;
        }
        public void PutMoneyToScore(double sum)
        {
            this.sum += sum;
        }
        public void AssessmentOfProsent(double Prosent)
        {
            sum = sum + sum * (Prosent / 100);
        }
        public void TranslateToDollar()
        {
            sum *= 341;
        }
        public void TranslateToEuro()
        {
            sum *= 423;
        }
        public void GetStringSum()
        {
            Console.Write("Сумма счета: ");
            Console.WriteLine(Convert.ToString(sum));
        }
        public void ShowScore()
        {
            Console.WriteLine("Владелец счета : {0}, номер счета : {1}, проценты начисление : {2}, сумма на счету : {3}",
               firstName, NumberScore, prosent, sum);
        }
        public Account(string Name, string Number, double Prosent, double sum)
        {
            firstName = Name;
            NumberScore = Number;
            prosent = Prosent;
            this.sum = sum;
            Console.WriteLine("Открыт новый счет!");
            Console.WriteLine("Владелец счета : {0}, номер счета : {1}, проценты начисление : {2}, сумма на счету : {3}", 
                firstName, NumberScore, prosent, sum);
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
            Account account = new Account(firstName, NumberScore, prosent, sum);
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
                    account.RemoveSum(Convert.ToDouble(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Какую сумму вы хотите положить?(Введите)");
                    account.PutMoneyToScore(Convert.ToDouble(Console.ReadLine()));
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
            Bank account = new Bank();
            Console.ReadKey();
        }
    }
}
