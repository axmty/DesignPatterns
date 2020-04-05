using System;

namespace DesignPatterns.Creational
{
    public class AbstractFactory
    {
        public AbstractClass Create(string letter)
        {
            return letter.ToLower() switch
            {
                "a" => new ConcreteClassA(),
                "b" => new ConcreteClassB(),
                _ => throw new ArgumentException(
                    "Must be an 'a' or a 'b' letter",
                    nameof(letter))
            };
        }
    }

    public abstract class AbstractClass
    {
        public abstract string Do();
    }

    public class ConcreteClassA : AbstractClass
    {
        public override string Do()
        {
            return "ConcreteClassA";
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        public override string Do()
        {
            return "ConcreteClassB";
        }
    }
}