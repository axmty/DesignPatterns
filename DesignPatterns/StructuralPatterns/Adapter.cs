using System;

namespace DesignPatterns.StructuralPatterns.Adapter
{
    /*
     *  Adapter is a structural design pattern that allows objects with
     *  incompatible interfaces to collaborate.
     *  
     *  PROS:
     *  - Single Responsibility Principle: separation of the data conversion from the primary business logic.
     *  - Open/Closed Principle: can introduce new types of adapters without breaking existing client code.
     *  CONS:
     *  - Code is more complex, since we need to introduce new interfaces and classes
     *    (is it possible / more simple to change the service class).
     */

    // Client class, contains existing business logic.
    class RoundHole
    {
        public virtual double Radius { get; init; }

        public bool Fits(RoundPeg roundPeg)
        {
            return this.Radius >= roundPeg.Radius;
        }
    }

    // Client interface, protocol that other classes must follow to be able to collaborate with the client (RoundHole).
    class RoundPeg
    {
        public virtual double Radius { get; init; }
    }

    // Service object (usually a useful 3rd-party or legacy class), cannot be used by the client as is (incompatible with RoundHole).
    class SquarePeg
    {
        public int Width { get; init; }
    }

    // Adapter, implements the client interface (RoundPeg), wraps the service object (SquarePeg).
    // Translates the calls from the client (RoundHole) into calls to the wrapped service object (SquarePeg).
    class SquarePegToRoundPegAdapter : RoundPeg
    {
        private readonly SquarePeg _squarePeg;

        public SquarePegToRoundPegAdapter(SquarePeg squarePeg)
        {
            _squarePeg = squarePeg;
        }

        public override double Radius
        { 
            get => _squarePeg.Width * Math.Sqrt(2) / 2;
            init => base.Radius = value; 
        }
    }

    static class Sample
    {
        public static void Do()
        {
            var hole = new RoundHole { Radius = 5 };
            var roundPeg = new RoundPeg { Radius = 5 };

            hole.Fits(roundPeg); // true

            var smallSquarePeg = new SquarePeg { Width = 2 };
            var largeSquarePeg = new SquarePeg { Width = 5 };

            // hole.Fits(smallSquarePeg); <= Does not compile.

            var smallSquareToRoundPegAdapter = new SquarePegToRoundPegAdapter(smallSquarePeg);
            var largeSquareToRoundPegAdapter = new SquarePegToRoundPegAdapter(largeSquarePeg);

            hole.Fits(smallSquareToRoundPegAdapter); // true
            hole.Fits(largeSquareToRoundPegAdapter); // false
        }
    }
}
