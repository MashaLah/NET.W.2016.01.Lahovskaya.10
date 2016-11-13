using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class Countdown
    {
        private int time;
        public Countdown(int time)
        {
            this.time = time;
        }
        public event EventHandler CountdownFinished;

        protected virtual void OnCountdownFinished(Object sender, EventArgs e)
        {
            CountdownFinished?.Invoke(sender, e);
        }

        public void StartCountdown()
        {
            for (int i = time; i > 0; i--)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
            OnCountdownFinished(this, new EventArgs());
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

        private void countdown_CountdownFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Hurray!");
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

        private void countdown_CountdownFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Oh no!");
        }
    }
}
