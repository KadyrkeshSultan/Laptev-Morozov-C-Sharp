using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppConsole
{
    class Time
    {
        int hour;
        int minute;
        int second;
        public Time(int Hour, int Minute, int Second)
        {
            hour = Hour;
            minute = Minute;
            second = Second;
        }
        public Time(int Seconds)
        {
            hour = Seconds / 3600;
            minute = (Seconds - (hour * 3600)) / 60;
            second = Seconds - (hour * 3600) - (minute * 60);
        }
        public Time(string str)
        {
            string[] array = str.Split(':');
            hour = Convert.ToInt32(array[0]);
            minute = Convert.ToInt32(array[1]);
            second = Convert.ToInt32(array[2]);
        }
        public Time(DateTime time)
        {
            hour = time.Hour;
            minute = time.Minute;
            second = time.Second;
        }
        public Time()
        {
        }
        public void Show()
        {
            Console.WriteLine("{0}, {1}, {2}", hour, minute, second);
        }
        public void ShowSecond()
        {
            Console.WriteLine((hour * 3600) + (minute * 60) + second);
        }
        private int TimeToSecond()
        {
            return (hour * 3600) + (minute * 60) + second;
        }
        private void SecondToTime(int Seconds)
        {
            hour = Seconds / 3600;
            minute = (Seconds - (hour * 3600)) / 60;
            second = Seconds - (hour * 3600) - (minute * 60);
        }
        public void ShowMinute()
        {
            int minutes;
            if (second < 30)
                minutes = (hour * 60) + minute;
            else
                minutes = (hour * 60) + minute + 1;
            Console.WriteLine(minutes);
        }
        public double GetMinute()
        {
            double minutes;
            if (second > 0)
                minutes = (hour * 60) + minute + 1;
            else
                minutes = (hour * 60) + minute;
            return minutes;
        }
        public static Time operator -(Time time1, Time time2)
        {
            Time time = new Time();
            int second = time1.TimeToSecond() - time2.TimeToSecond();
            if (second < 0)
                second *= (-1);
            time.second = second;
            time.ShowSecond();
            return time;
        }
        public static Time operator -(Time time1, int seconds)
        {
            Time now = new Time();
            now.SecondToTime(time1.TimeToSecond() - seconds);
            return now;
        }
        public static Time operator +(Time time1, int seconds)
        {
            Time now = new Time();
            now.SecondToTime(time1.TimeToSecond() + seconds);
            return now;
        }
    }
    class Bill
    {
        string surname;
        string number;
        double rate;
        double sale;
        Time timeStart;
        Time timeEnd;
        double sum;
        public double GetSum()
        {
            sum = (timeEnd.GetMinute() - timeStart.GetMinute()) * (double)rate;
            sum -= sum * (sale / 100);
            return sum;
        }
        public Bill(string Surname, string Number, double Rate, double Sale, Time Start, Time End)
        {
            surname = Surname;
            number = Number;
            rate = Rate;
            sale = Sale;
            timeStart = Start;
            timeEnd = End;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bill bill = new Bill("Kadyrkesh", "20-69-79", 7, 10, new Time(DateTime.Now), new Time(20, 56, 25));
            Console.WriteLine(bill.GetSum());
            Console.ReadKey();
            
        }
    }
}
