using DesignPatterns.Creational.AbstractFactory;
using Xunit;

namespace DesignPatterns.Tests.Creational
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void Create_ReturnsConcreteProduct1Instance_WithConcreteFactory1()
        {
            this.CreateAndAssert<ConcreteProduct1>(1);
        }

        [Fact]
        public void Create_ReturnsConcreteProduct2Instance_WithConcreteFactory2()
        {
            this.CreateAndAssert<ConcreteProduct2>(2);
        }

        private void CreateAndAssert<TExpectedConcrete>(int concreteFactoryNumber)
            where TExpectedConcrete : AbstractProduct, new()
        {
            var factory = AbstractFactory.GetFactory(concreteFactoryNumber);

            var product = factory.Create();

            Assert.IsType<TExpectedConcrete>(product);
        }
    }
}