using System;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main()
        {
            CreationalPatterns.FactoryMethod.Test.Do<CreationalPatterns.FactoryMethod.CatFeeder>();
            CreationalPatterns.FactoryMethod.Test.Do<CreationalPatterns.FactoryMethod.DogFeeder>();

            Console.WriteLine();

            CreationalPatterns.AbstractFactory.Test.Do<CreationalPatterns.AbstractFactory.ModernFurnitureFactory>();
            CreationalPatterns.AbstractFactory.Test.Do<CreationalPatterns.AbstractFactory.VictorianFurnitureFactory>();
        }
    }
}
