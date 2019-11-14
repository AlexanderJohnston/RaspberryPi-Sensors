using System;
using System.Threading;
using Bifrost.Devices.Gpio;
using Bifrost.Devices.Gpio.Abstractions;
using Bifrost.Devices.Gpio.Core;

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
                Console.WriteLine(pressed.KeyChar);
                sensor.Get(7);
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
        public void Get(int pin) => Console.WriteLine($"Value from pin {pin}: {Read(pin)}");

        private string Read(int pin)
        {
            GpioPinValue status;
            Console.WriteLine($"Reading pin {(Pinout)pin}");
            var signal = gpioController.OpenPin(pin);
            status = signal.Read();
            return status.ToString();
        }
    }

    public enum Pinout
    {
        Power3v = 1,
        Power5v = 2,
        Spi3Mosi = 3,
        Power5v2 = 4,
        Spi3Sclk = 5,
        Ground = 6,
        Spi4Ce0N = 7,
        Txd1Mosi = 8,
        Ground2 = 9,
    }
}
