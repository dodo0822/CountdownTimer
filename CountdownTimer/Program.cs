using System;
using System.Threading;
using System.IO;

namespace CountdownTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = new DateTime(2021, 1, 1, 0, 0, 0);
            Console.WriteLine("Starting count down..");
            while (true)
            {
                var delta = target - DateTime.Now;
                var line = string.Format("{0:00}:{1:00}:{2:00}", Math.Floor(delta.TotalHours), delta.Minutes, delta.Seconds);
                try
                {
                    Console.Write("\r{0}", line);
                    File.WriteAllText("Timer.txt", line);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError: {0}", e);
                }
                Thread.Sleep(100);
            }
        }
    }
}
