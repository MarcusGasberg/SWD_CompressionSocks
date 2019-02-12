using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionSocks
{

    public interface IMotor
    {
        bool Running { get; }
        void RunForward();
        void RunBackwards();
        void Stop();
    }

    public class LacesMotor : IMotor
    {
        public bool Running { get; private set; } = false;
        public void RunForward()
        {
            Console.WriteLine("*Tightening Laces*");
            Running = true;
        }

        public void RunBackwards()
        {
            Console.WriteLine("*Loosening Laces*");
            Running = true;
        }

        public void Stop()
        {
            Console.WriteLine("Lace Motor stopped");
            Running = false;
        }
    }


    public class AirPump : IMotor
    {
        public bool Running { get; private set; } = false;

        public void RunForward()
        {
            Console.WriteLine("Pump running forward");
            Running = true;
        }

        public void RunBackwards()
        {
            Console.WriteLine("Pump running backwards");
            Running = true;
        }

        public void Stop()
        {
            Console.WriteLine("Pump stopped");
            Running = false;
        }
    }
}
