using System;

namespace CompressionSocks
{
    public interface ICompressionCtrl
    {
        bool Compressed { get; }
        void Compress();
        void Decompress();
    }


    public class CompressionControl : ICompressionCtrl
    {
        protected readonly ITimer _timer;
        protected readonly IMotor _motor;

        public CompressionControl(IMotor motor, ITimer timer)
        {
            _motor = motor;
            _timer = timer;
        }

        public bool Compressed { get; protected set; }
        public int DelayCompress { get; set; } = 5000;
        public int DelayDecompress { get; set; } = 2000;
        
        public virtual void Compress()
        {
            if (Compressed || _motor.Running) return;

            Console.WriteLine("Compressing...");
            _motor.RunForward();
            _timer.Delay(DelayCompress, _motor.Stop);
            Compressed = true;
        }

        public virtual void Decompress()
        {
            if (!Compressed || _motor.Running) return;

            Console.WriteLine("Decompressing...");
            _motor.RunBackwards();
            _timer.Delay(DelayDecompress, _motor.Stop);
            Compressed = false;
        }
    }

    public class CompressionControlWithLedAndVibration : CompressionControl
    {
        public CompressionControlWithLedAndVibration(IMotor motor, ITimer timer) : base(motor, timer)
        {
        }

        public ILed CompressingLed { get; set; } = new GreenLed();

        public ILed DecompressingLed { get; set; } = new RedLed();

        public IVibrate Vibrator { get; set; } = new Vibrator();
        public override void Compress()
        {
            if (Compressed || _motor.Running) return;
            
            CompressingLed.TurnOn();
            Vibrator.Vibrate();
            _motor.RunForward();
            _timer.Delay(DelayCompress, ()=>
            {
                _motor.Stop();
                Compressed = true;
                CompressingLed.TurnOff();
                Vibrator.Stop();
            });
        }

        public override void Decompress()
        {
            if (!Compressed || _motor.Running) return;

            DecompressingLed.TurnOn();
            Vibrator.Vibrate();
            _motor.RunBackwards();
            _timer.Delay(DelayDecompress, ()=>
            {
                _motor.Stop();
                Compressed = false;
                DecompressingLed.TurnOff();
                Vibrator.Stop();
            });
        }
    }
}