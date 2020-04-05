namespace DesignPatterns.Creational.Builder
{
    public interface IProductBuilder
    {
        Product Build();
    }

    public class ProductBuilderA : IProductBuilder
    {
        public Product Build()
        {
            return new Product
            {
                BoolProperty = false,
                IntProperty = 0,
                DoubleProperty = 0.0,
                StringProperty = "",
            };
        }
    }

    public class ProductBuilderB : IProductBuilder
    {
        public Product Build()
        {
            return new Product
            {
                BoolProperty = true,
                IntProperty = 1,
                DoubleProperty = 1.0,
                StringProperty = "string",
            };
        }
    }

    public class Product
    {
        public bool BoolProperty { get; set; }

        public int IntProperty { get; set; }

        public double DoubleProperty { get; set; }

        public string StringProperty { get; set; }
    }
}