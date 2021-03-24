namespace DesignPatterns.CreationalPatterns.Builder
{
    /*
     *  Builder is a creational design pattern that lets you construct
     *  complex objects step by step. The pattern allows you to
     *  produce different types and representations of an object using
     *  the same construction code.
     *  
     *  PROS:
     *  - Construct objects step by step, removing complex class constructors.
     *  - Can reuse same construction code to build various representations of products (Car and CarManual).
     *  - Single Responsibility Principle: the code to build complex objects is isolated from the business logic.
     *  CONS:
     *  - Code is more complex, new concepts / classes are introduced.
     */

    // Builder interface, specifies the different steps of product construction.
    public interface IBuilder
    {
        void Reset();

        void SetSeats(int numberSeats);

        void SetEngine(string engine);

        void SetGPS(bool gps);
    }

    // Concrete builders.
    public class CarBuilder : IBuilder
    {
        private Car _car;

        public CarBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            _car = new Car();
        }

        public void SetSeats(int numberSeats)
        {
            _car.Seats = numberSeats;
        }

        public void SetEngine(string engine)
        {
            _car.Engine = engine;
        }

        public void SetGPS(bool gps)
        {
            _car.GPS = gps;
        }

        public Car Build()
        {
            var result = _car;
            this.Reset();
            return result;
        }
    }

    public class CarManualBuilder : IBuilder
    {
        private CarManual _carManual;

        public CarManualBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            _carManual = new CarManual();
        }

        public void SetSeats(int numberSeats)
        {
            _carManual.Seats = numberSeats;
        }

        public void SetEngine(string engine)
        {
            _carManual.Engine = engine;
        }

        public void SetGPS(bool gps)
        {
            _carManual.GPS = gps;
        }

        public CarManual Build()
        {
            var result = _carManual;
            this.Reset();
            return result;
        }
    }

    // Products that can be constructed step by step with the builder.
    public class Car
    {
        public int Seats { get; set; }

        public bool GPS { get; set; }

        public string Engine { get; set; }
    }

    public class CarManual
    {
        public int Seats { get; set; }

        public bool GPS { get; set; }

        public string Engine { get; set; }
    }

    // Director responsible for building steps in a particular sequence, to build particular objects.
    public class Director
    {
        public void ConstructSportsCar(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(2);
            builder.SetEngine("sport_engine");
            builder.SetGPS(false);
        }

        public void ConstructSUV(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(6);
            builder.SetEngine("suv_engine");
            builder.SetGPS(true);
        }
    }

    public static class Test
    {
        public static void Do()
        {
            var director = new Director();
            var builder = new CarBuilder();

            director.ConstructSportsCar(builder);
            var car = builder.Build();

            director.ConstructSUV(builder);
            var carManual = builder.Build();
        }
    }
}
