using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionSocks
{
    public interface ILed
    {
        void TurnOn();
        void TurnOff();
    }

    public class RedLed : ILed
    {
        public void TurnOn() => Console.WriteLine("*Red LED Turned on*");
        public void TurnOff() => Console.WriteLine("*Red LED Turned off*");
    }


    public class GreenLed : ILed
    {
        public void TurnOn() => Console.WriteLine("*Green LED Turned on*");

        public void TurnOff() => Console.WriteLine("*Green LED Turned off");
    }
}
