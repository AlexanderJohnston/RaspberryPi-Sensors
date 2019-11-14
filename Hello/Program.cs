using System;
using System.Threading;
using Bifrost.Devices.Gpio;
using Bifrost.Devices.Gpio.Abstractions;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Raspberry Pi!");
            var sensor = new Sensor();
            Console.WriteLine("--- Reading Pins --- Press X To Quit ---");
            var pressed = Console.ReadKey();
            while (pressed.Key != ConsoleKey.X)
            {
                sensor.Get();
                Thread.Sleep(500);
            }
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
