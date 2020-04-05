using System;
using DesignPatterns.Creational.Builder;
using Xunit;

namespace DesignPatterns.Tests.Creational
{
    public class BuilderTests
    {
        [Theory]
        [InlineData(typeof(FalsyProductBuilder), false, 0)]
        [InlineData(typeof(TruthyProductBuilder), true, 1)]
        public void Construct_ReturnsProduct_CorrespondingToTheBuilderUsed(
            Type builderType,
            bool expectedBoolProperty,
            int expectedIntProperty)
        {
            var builder = (ProductBuilder)Activator.CreateInstance(builderType);
            var director = new Director(builder);

            var result = director.Construct();

            Assert.Equal(expectedBoolProperty, result.BoolProperty);
            Assert.Equal(expectedIntProperty, result.IntProperty);
        }
    }
}