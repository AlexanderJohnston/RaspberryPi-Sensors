using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Raspberry Pi!");
            IBootstrap
            Pi.Init<>();
            var sensor = new Sensor();
            Console.WriteLine("--- Reading Pins --- Press X To Quit ---");
            var pressed = Console.ReadKey();
            do
            {
                Console.WriteLine(pressed.KeyChar);
                sensor.Get(6);
                sensor.Get(7);
                pressed = Console.ReadKey();
            } while (pressed.Key != ConsoleKey.X);
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
