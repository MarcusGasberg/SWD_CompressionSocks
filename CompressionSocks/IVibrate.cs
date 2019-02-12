using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionSocks
{
    public interface IVibrate
    {
        void Vibrate();
        void Stop();
    }

    public class Vibrator : IVibrate
    {
        public void Vibrate()
        {
            Console.WriteLine("*bzzzt*");
        }

        public void Stop()
        {
            Console.WriteLine("*Vibrator Stops*");
        }
    }
}
