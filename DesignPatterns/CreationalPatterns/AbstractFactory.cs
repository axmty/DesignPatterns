using System;

namespace DesignPatterns.CreationalPatterns.AbstractFactory
{
    /*
     *  Abstract Factory is a creational design pattern that lets you
     *  produce families of related objects without specifying their
     *  concrete classes.
     *  
     *  PROS:
     *  - Ensure that the products created by a factory are compatible with each other.
     *  - Avoid tight coupling between concrete products and client code.
     *  - Single Responsibility Principle: the code that creates the products is isolated (within the factories themselves).
     *  - Open/Closed Principle: easy to add new variants of products without touching the client code.
     *  CONS:
     *  - Code is more complex since new interfaces and classes are introduced.
     */

    // The abstract factory has methods that return abstract products.
    public interface IFurnitureFactory
    {
        IChair CreateChair();

        ISofa CreateSofa();
    }

    // Concrete factories produce a family of concrete products.
    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new VictorianChair();

        public ISofa CreateSofa() => new VictorianSofa();
    }

    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ModernChair();

        public ISofa CreateSofa() => new ModernSofa();
    }

    // Abstract product.
    public interface IChair
    {
        bool HasLegs { get; }

        void SitOn();
    }

    // Concrete products.
    public class VictorianChair : IChair
    {
        public bool HasLegs => true;

        public void SitOn()
        {
            Console.WriteLine("This is quite comfortable...");
        }
    }

    public class ModernChair : IChair
    {
        public bool HasLegs => false;

        public void SitOn()
        {
            Console.WriteLine("This is nice but not really comfortable...");
        }
    }

    // Another abstract product.
    public interface ISofa
    {
        bool IsSofaBed { get; }
    }

    // Another concrete products.
    public class VictorianSofa : ISofa
    {
        public bool IsSofaBed => false;
    }

    public class ModernSofa : ISofa
    {
        public bool IsSofaBed => true;
    }
    
    public static class Test
    {
        public static void Do<TFactory>()
            where TFactory : IFurnitureFactory, new()
        {
            var factory = new TFactory();
            
            var chair = factory.CreateChair();
            var sofa = factory.CreateSofa();

            chair.SitOn();
            Console.WriteLine($"Is this a sofa bed? {(sofa.IsSofaBed ? "Yes" : "No")}.");
        }
    }
}
