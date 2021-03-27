using System.Collections.Generic;

namespace DesignPatterns.CreationalPatterns.Prototype
{
    /*
     *  Prototype is a creational design pattern that lets you copy
     *  existing objects without making your code dependent on
     *  their classes.
     *  
     *  PROS:
     *  - Can clone without coupling to the concrete classes (just need to use myObject.Clone()).
     *  - No repeated initialization code, just need to clone pre-build prototypes.
     *  - Convenient for producing complex objects.
     *  - Alternative to inheritance : don't need superclasses that deal with configuration presets.
     *  CONS:
     *  - Difficult to clone objects that have circular references.
     */

    // Base prototype.
    public abstract class Shape
    {
        private readonly int _x;

        private readonly int _y;

        private readonly string _color;

        protected Shape(int x, int y, string color)
        {
            this._x = x;
            this._y = y;
            this._color = color;
        }

        protected Shape(Shape other) : this(other._x, other._y, other._color)
        {
        }

        public abstract Shape Clone();
    }

    // Concrete prototypes.
    public class Rectangle : Shape
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle(int x, int y, string color, int width, int height) : base(x, y, color)
        {
            this._width = width;
            this._height = height;
        }

        public Rectangle(Rectangle other) : base(other)
        {
            this._width = other._width;
            this._height = other._height;
        }

        public override Shape Clone()
        {
            return new Rectangle(this);
        }
    }

    public class Circle : Shape
    {
        private readonly int _radius;

        public Circle(int x, int y, string color, int radius) : base(x, y, color)
        {
            this._radius = radius;
        }

        public Circle(Circle other) : base(other)
        {
            this._radius = other._radius;
        }

        public override Shape Clone()
        {
            return new Circle(this);
        }
    }

    // Client code.
    public class Application
    {
        private readonly List<Shape> _shapes = new();

        public Application()
        {
            Circle circle = new(1, 2, "red", 3);
            _shapes.Add(circle);

            Shape anotherCircle = circle.Clone(); // Clone's return type is Shape.
            _shapes.Add(anotherCircle);

            Rectangle rectangle = new(1, 2, "blue", 4, 5);
            _shapes.Add(rectangle);

            Shape anotherRectangle = rectangle.Clone();
            _shapes.Add(anotherRectangle);
        }

        public List<Shape> BusinessLogic()
        {
            List<Shape> shapesCopy = new();

            foreach (var s in _shapes)
            {
                shapesCopy.Add(s.Clone()); // Don't need to worry about the concrete classes.
            }

            return shapesCopy;
        }
    }

    public static class Test
    {
        public static void Do()
        {
            var app = new Application();
            var shapesCopy = app.BusinessLogic();
        }
    }
}
