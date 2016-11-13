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
        public event EventHandler<CountdownFinishedEventArgs> CountdownFinished = delegate { };

        protected virtual void OnCountdownFinished(CountdownFinishedEventArgs e)
        {
            EventHandler<CountdownFinishedEventArgs> temp = CountdownFinished;
            temp?.Invoke(this, e);
        }

        public void StartCountdown(string message)
        {
            Thread.Sleep(1000 * time);
            OnCountdownFinished(new CountdownFinishedEventArgs(message));
        }
    }

    public sealed class CountdownFinishedEventArgs : EventArgs
    {
        public CountdownFinishedEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
