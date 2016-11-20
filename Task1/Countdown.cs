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

        /// <summary>
        /// Declare the event.
        /// </summary>
        public event EventHandler<CountdownFinishedEventArgs> CountdownFinished = delegate { };

        /// <summary>
        /// Informs listeners about event.
        /// </summary>
        /// <param name="e">Message to listeners.</param>
        protected virtual void OnCountdownFinished(CountdownFinishedEventArgs e)
        {
            EventHandler<CountdownFinishedEventArgs> temp = CountdownFinished;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Put input data into event.
        /// </summary>
        /// <param name="message">Data that method will transfer to event</param>
        public void StartCountdown(string message)
        {
            Thread.Sleep(1000 * time);
            OnCountdownFinished(new CountdownFinishedEventArgs(message));
        }
    }

    /// <summary>
    /// Information that listeners will receive.
    /// </summary>
    public sealed class CountdownFinishedEventArgs : EventArgs
    {
        public CountdownFinishedEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
