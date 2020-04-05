using System;

namespace DesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// The client uses this AbstractFactory to first get a ConcreteFactory.
    /// Either ConcreteFactory1 or ConcreteFactory2.
    /// Then the client uses the AbstractFactory.Create method,
    /// whose implementation depends on the instanciated Concrete Factory.
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// Instanciates one of the ConcreteFactory.
        /// Here, we use a parameter to determine which Concrete Factory should be instanciated.static
        /// But we could consider other scenarios where a config file is read to determine it.
        /// </summary>
        public static AbstractFactory GetFactory(int concreteFactoryNumber)
        {
            return concreteFactoryNumber switch
            {
                1 => new ConcreteFactory1(),
                2 => new ConcreteFactory2(),
                _ => throw new ArgumentException("Must be 1 or 2", nameof(concreteFactoryNumber))
            };
        }

        public abstract AbstractProduct Create();
    }

    /// <summary>
    /// This factory will instanciate ConcreteProduct1 objects.
    /// </summary>
    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProduct Create()
        {
            return new ConcreteProduct1();
        }
    }

    /// <summary>
    /// This factory will instanciate ConcreteProduct2 objects.
    /// </summary>
    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProduct Create()
        {
            return new ConcreteProduct2();
        }
    }

    public abstract class AbstractProduct { }

    public class ConcreteProduct1 : AbstractProduct { }

    public class ConcreteProduct2 : AbstractProduct { }
}