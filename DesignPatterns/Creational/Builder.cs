namespace DesignPatterns.Creational.Builder
{
    /// <summary>
    /// The client first instanciates one of the concrete ProductBuilder.
    /// Then, it instanciates a new Director with that Builder.
    /// The Director.Construct method builds the different parts of the product,
    /// with the different ProductBuilder.BuildPart*** methods.
    /// </summary>
    public class Director
    {
        private readonly ProductBuilder _builder;

        public Director(ProductBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// "Assembles" the product by building the different parts of it, and returns it.
        /// </summary>
        public Product Construct()
        {
            _builder.BuildPartBool();
            _builder.BuildPartInt();

            return _builder.Result;
        }
    }

    /// <summary>
    /// Abstract Builder that defines how the building of the different parts will be implemented
    /// within the specific concrete Builders.
    /// </summary>
    public abstract class ProductBuilder
    {
        /// <summary>
        /// With this property, the Builder will be able to create only one Product.
        /// We can imagine another method that will instanciate a Product at each call:
        /// public Product GetResult() 
        /// {
        ///     return new Product { BoolProperty = this.BoolToSet, IntProperty = this.IntToSet };
        /// }
        /// where BoolProperty and IntProperty would be properties set by the BuildPart*** methods.
        /// </summary>
        public Product Result { get; } = new Product();

        public abstract void BuildPartBool();

        public abstract void BuildPartInt();
    }

    /// <summary>
    /// This builder will build the different parts of the product with falsy values.
    /// </summary>
    public class FalsyProductBuilder : ProductBuilder
    {
        public override void BuildPartBool()
        {
            this.Result.BoolProperty = false;
        }

        public override void BuildPartInt()
        {
            this.Result.IntProperty = 0;
        }
    }

    /// <summary>
    /// This builder will build the different parts of the product with truthy values.
    /// </summary>
    public class TruthyProductBuilder : ProductBuilder
    {
        public override void BuildPartBool()
        {
            this.Result.BoolProperty = true;
        }

        public override void BuildPartInt()
        {
            this.Result.IntProperty = 1;
        }
    }

    public class Product
    {
        public bool BoolProperty { get; set; }

        public int IntProperty { get; set; }
    }
}