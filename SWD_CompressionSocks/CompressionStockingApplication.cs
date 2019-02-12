using System;
using CompressionSocks;

namespace SWD_CompressionSocks
{

    class StubCompressionCtrl : ICompressionCtrl
    {
        public bool Compressed { get; }

        public void Compress()
        {
            Console.WriteLine("StubCompressionCtrl::Compress() called");
        }

        public void Decompress()
        {
            Console.WriteLine("StubCompressionCtrl::Decompress() called");
        }
    }



    class CompressionStockingApplication
    {
        static void Main(string[] args)
        {
            var compressionStockingstocking = new StockingCtrl(new CompressionControlWithLedAndVibration(new LacesMotor(), new OSTimer()));
            ConsoleKeyInfo consoleKeyInfo;
            
            Console.WriteLine("Compression Stocking Control User Interface");
            Console.WriteLine("A:   Compress");
            Console.WriteLine("Z:   Decompress");
            Console.WriteLine("ESC: Terminate application");

            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character
                if (consoleKeyInfo.Key == ConsoleKey.A)  compressionStockingstocking.StartBtnPushed();
                if (consoleKeyInfo.Key == ConsoleKey.Z)  compressionStockingstocking.StopBtnPushed();

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
