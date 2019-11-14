using System;
using Bifrost.Devices.Gpio;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Sensor
    {
        private IGpioController gpioController;
        public Sensor()
        {
            Console.WriteLine("Setting up GPIO pin controller.");
            gpioController = GpioController.Instance;
        }
        public void Get() => Console.WriteLine(gpioController.Pins);
    }
}
