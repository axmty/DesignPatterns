using System;

namespace DesignPatterns.CreationalPatterns.FactoryMethod
{
    /*
        Factory Method is a creational design pattern that provides
        an interface for creating objects in a superclass, but allows
        subclasses to alter the type of objects that will be created.
     */

    // The base creator class declares the factory method CreateAnimal.
    public abstract class AnimalFeeder
    {
        protected abstract IAnimal CreateAnimal(); // May provide default implementation.

        public void Feed()
        {
            var animal = this.CreateAnimal();
            Console.WriteLine(animal.Talk());
            Console.WriteLine($"Giving some {animal.Food()} to the animal.");
            Console.WriteLine(animal.Talk());
        }
    }

    // Concrete creators override the factory method to change the type of the created product.
    public class CatFeeder : AnimalFeeder
    {
        protected override IAnimal CreateAnimal()
        {
            return new Cat();
        }
    }

    public class DogFeeder : AnimalFeeder
    {
        protected override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }

    // Product interface.
    public interface IAnimal
    {
        string Food();

        string Talk();
    }

    // Concrete products created by the concrete creators.
    public class Cat : IAnimal
    {
        public string Food() => "fish";

        public string Talk() => "miaouuu!";
    }

    public class Dog : IAnimal
    {
        public string Food() => "dry food";

        public string Talk() => "wouaff!";
    }

    public static class Test
    {
        public static void Do<TAnimalFeeder>()
            where TAnimalFeeder : AnimalFeeder, new()
        {
            var animalFeeder = new TAnimalFeeder();
            animalFeeder.Feed();
        }
    }
}
