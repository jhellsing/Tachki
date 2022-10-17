using System;
using System.Threading;

namespace Film_drive
{
    internal class Car
    {
        double Road = 1000;
        double kmSpeed;
        Random rand = new Random();
        double AllSpeed = 0;
        double sredspeed;
        double time = 0;
        double OstSec;
        double msSpeed;
        public void dvij()
        {
            Thread myThread = new Thread(write);
            myThread.Start();
            for (; Road > 0; Road -= msSpeed)
            {
                kmSpeed = rand.Next(87, 95);
                AllSpeed += kmSpeed;
                time++;
                sredspeed = AllSpeed / time;
                msSpeed = (kmSpeed / 3.6);
                OstSec = (Road / (sredspeed / 3.6));
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public void write()
        {
            for (; Road > 0;)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e);
                }
                if (Road < 27)
                {
                    Console.Clear();
                    Road = 0;
                    kmSpeed = 0;
                    OstSec = 0;
                    Console.WriteLine("Текущая скорость: " + kmSpeed + " км/ч");
                    Console.WriteLine("Средняя скорость: " + Math.Round(sredspeed, 3) + " км/ч");
                    Console.WriteLine("Осталось ехать: " + Road + " м");
                    Console.WriteLine("Времени до прибытия: " + OstSec + " c");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Текущая скорость: " + kmSpeed + " км/ч");
                    Console.WriteLine("Средняя скорость: " + Math.Round(sredspeed, 3) + " км/ч");
                    Console.WriteLine("Осталось ехать: " + Math.Round(Road, 2) + " м");
                    Console.WriteLine("Времени до прибытия: " + Math.Round(OstSec, 2) + " c\n");
                }
            }
        }
    }
}
