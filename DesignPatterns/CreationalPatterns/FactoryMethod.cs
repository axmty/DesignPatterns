﻿using System;

namespace DesignPatterns.CreationalPatterns.FactoryMethod
{
    /*
     *  Factory Method is a creational design pattern that provides
     *  an interface for creating objects in a superclass, but allows
     *  subclasses to alter the type of objects that will be created.
     *  
     *  PROS:
     *  - Single Responsibility Principle: the code that creates the product is isolated (within the factory method CreateAnimal).
     *  - Open/Closed Principle: easy to add new types of products without touching the AnimalFeeder.Feed or Test.Do methods.
     *  CONS:
     *  - May introduce several classes.
     */

    // The base creator class declares the factory method CreateAnimal.
    abstract class AnimalFeeder
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
    class CatFeeder : AnimalFeeder
    {
        protected override IAnimal CreateAnimal()
        {
            return new Cat();
        }
    }

    class DogFeeder : AnimalFeeder
    {
        protected override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }

    // Product interface.
    interface IAnimal
    {
        string Food();

        string Talk();
    }

    // Concrete products created by the concrete creators.
    class Cat : IAnimal
    {
        public string Food() => "fish";

        public string Talk() => "miaouuu!";
    }

    class Dog : IAnimal
    {
        public string Food() => "dry food";

        public string Talk() => "wouaff!";
    }

    static class Sample
    {
        public static void Do()
        {
            AnimalFeeder animalFeeder = new CatFeeder();
            animalFeeder.Feed(); // Internally, create an animal (a cat) with the factory method (CreateAnimal).
        }
    }
}
