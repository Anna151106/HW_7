using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }

    abstract class Car
    {
        public abstract void Info();
    }

    abstract class Engine
    {
        public abstract void GetPower();
    }

    class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    class Mercedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mercedes");
        }
    }

    class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine 4.4");
        }
    }

    class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine 3.2");
        }
    }

    class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine 5.0");
        }
    }

    class FordFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Ford();
        }

        public Engine CreateEngine()
        {
            return new FordEngine();
        }
    }

    class ToyotaFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Toyota();
        }

        public Engine CreateEngine()
        {
            return new ToyotaEngine();
        }
    }

    class MercedesFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Mercedes();
        }

        public Engine CreateEngine()
        {
            return new MercedesEngine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Toyota ---");
            ICarFactory carFactory = new ToyotaFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            Console.WriteLine("\n--- Ford ---");
            carFactory = new FordFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            Console.WriteLine("\n--- Mercedes ---");
            carFactory = new MercedesFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            Console.ReadKey();
        }
    }
}