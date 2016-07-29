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
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(DateTime.Now);
            Time time2 = new Time(1000);
            time1 = time2 - 9;
            time1.ShowSecond();
            time1 = time2 + 9;
            time1.ShowSecond();
            time2.ShowMinute();
            Console.ReadKey();
        }
    }
}
