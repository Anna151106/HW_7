using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new ConcreteProductA();
                //повертає об'єкт B, якщо type==2  
                case 2: return new ConcreteProductB();
                case 3: return new ConcreteProductC();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product { } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class ConcreteProductA : Product { }

    public class ConcreteProductB : Product { }

    public class ConcreteProductC : Product { }

    class MainApp
    {
        static void Main()
        {
            Creator creator = new ConcreteCreator();

            for (int i = 1; i <= 3; i++)
            {
                var product = creator.FactoryMethod(i);
                Console.WriteLine($"Where id = {i}, Created {product.GetType()}");
            }

            Console.ReadKey();

        }
    }
}

