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
            countdown.StartCountdown("Countdown run");
            negativeListener.Unregister(countdown);
            countdown.StartCountdown("Countdown run again");
            Console.ReadLine();
        }
    }

    public class PositiveListener
    {
        public PositiveListener(Countdown countdown)
        {
            countdown.CountdownFinished += countdown_CountdownFinished;
        }

        public void Unregister(Countdown countdown)
        {
            countdown.CountdownFinished -= countdown_CountdownFinished;
        }

        private void countdown_CountdownFinished(object sender, CountdownFinishedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public class NegativeListener
    {
        public NegativeListener(Countdown countdown)
        {
            countdown.CountdownFinished += countdown_CountdownFinished;
        }

        public void Unregister(Countdown countdown)
        {
            countdown.CountdownFinished -= countdown_CountdownFinished;
        }

        private void countdown_CountdownFinished(object sender, CountdownFinishedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
