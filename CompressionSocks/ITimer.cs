using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CompressionSocks
{
    public interface ITimer
    {
        void Delay(int amount, Action action);
    }

    public class OSTimer : ITimer
    {
        private Timer _timer;

        public void Delay(int amount, Action action)
        {
            _timer = new Timer();
            _timer.Interval = amount;
            _timer.Elapsed += (s, e) =>
            {
                action.Invoke();
                _timer.Stop();
            };
            _timer.Start();
        }
    }
}
