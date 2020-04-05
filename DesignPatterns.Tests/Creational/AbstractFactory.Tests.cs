using DesignPatterns.Creational;
using Xunit;

namespace DesignPatterns.Tests.Creational
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void Create_ReturnsConcreteClassAInstance_WhenAskingForIt()
        {
            this.CreateAndAssert<ConcreteClassA>("a");
        }

        [Fact]
        public void Create_ReturnsConcreteClassBInstance_WhenAskingForIt()
        {
            this.CreateAndAssert<ConcreteClassB>("b");
        }

        private void CreateAndAssert<TExpectedConcrete>(string createParam)
            where TExpectedConcrete : AbstractClass, new()
        {
            var factory = new AbstractFactory();

            var instance = factory.Create(createParam);

            Assert.IsType<TExpectedConcrete>(instance);
        }
    }
}