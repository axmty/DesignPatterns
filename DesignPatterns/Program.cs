using DesignPatterns.CreationalPatterns.FactoryMethod;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main()
        {
            Test.Do<CatFeeder>();
            Test.Do<DogFeeder>();
        }
    }
}
