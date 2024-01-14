using System;
using CustomTimer.EventArgsClasses;
using CustomTimer.Interfaces;
#pragma warning disable

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        private Timer timer;

        public CountDownNotifier(Timer timer)
        {
            this.timer = timer;
        }

        /// <inheritdoc/>
        public void Init(EventHandler<StartedEventArgs>? startHandler, EventHandler<StoppedEventArgs>? stopHandler, EventHandler<TickEventArgs>? tickHandler)
        {
            if (timer != null)
            {
                timer.Started += startHandler;
                timer.Stopped += stopHandler;
                timer.Tick += tickHandler;
            }
            else
            {
                throw new InvalidOperationException("Timer not set for CountDownNotifier.");
            }
        }

        /// <inheritdoc/>
        public void Run()
        {
            if (timer != null)
            {
                timer.Run();
            }
            else
            {
                throw new InvalidOperationException("Timer not set for CountDownNotifier.");
            }
        }
    }
}
