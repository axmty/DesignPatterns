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
            _x = x;
            _y = y;
            _color = color;
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
            _width = width;
            _height = height;
        }

        public Rectangle(Rectangle other) : base(other)
        {
            _width = other._width;
            _height = other._height;
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
            _radius = radius;
        }

        public Circle(Circle other) : base(other)
        {
            _radius = other._radius;
        }

        public override Shape Clone()
        {
            return new Circle(this);
        }
    }

    public static class Sample
    {
        public static void Do()
        {
            List<Shape> shapes = new();

            Circle circle = new(1, 2, "red", 3);
            shapes.Add(circle);

            Shape anotherCircle = circle.Clone(); // Clone's return type is Shape.
            shapes.Add(anotherCircle);

            Rectangle rectangle = new(1, 2, "blue", 4, 5);
            shapes.Add(rectangle);

            Shape anotherRectangle = rectangle.Clone();
            shapes.Add(anotherRectangle);

            List<Shape> shapeCopies = new();

            foreach (var s in shapes)
            {
                shapeCopies.Add(s.Clone()); // Don't need to worry about the concrete classes.
            }
        }
    }
}
