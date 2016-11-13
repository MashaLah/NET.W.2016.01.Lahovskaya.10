using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter time:");
            int time = int.Parse(Console.ReadLine());
            Countdown countdown = new Countdown(time);
            PositiveListener positiveListener = new PositiveListener(countdown);
            NegativeListener negativeListener = new NegativeListener(countdown);
            countdown.StartCountdown();
            Console.ReadLine();
        }
    }
}
