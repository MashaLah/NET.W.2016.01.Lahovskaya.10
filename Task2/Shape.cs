using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task2
{
    public abstract class Shape
    {
        abstract public double Perimeter();
        abstract public double Area();
    }

    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException($"Parameter {nameof(radius)} must be > 0.");
            this.radius = radius;
        }
        public override double Perimeter() => 2 * PI * radius;
        public override double Area() => PI * Pow(radius, 2);
    }

    public class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Every parameter must be > 0.");
            if (sideA > sideB + sideC || sideB > sideA + sideC || sideC > sideA + sideB)
                throw new ArgumentException("It is impossible to make a triangle with entered length of sides.");
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        public override double Perimeter() => sideA + sideB + sideC;
        public override double Area() =>
            Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        private double halfPerimeter => Perimeter() / 2;
    }

    public class Square : Shape 
    {
        private double side;
        public Square(double side)
        {
            if (side <= 0) throw new ArgumentException($"Parameter {nameof(side) } must be > 0.");
            this.side = side;
        }
        public override double Perimeter() => side * 4;
        public override double Area() => Pow(side, 2);
    }

    public class Rectangle : Shape
    {
        private double sideA;
        private double sideB;
        public Rectangle(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0) throw new ArgumentException("Every parameter must be > 0.");
            this.sideA = sideA;
            this.sideB = sideB;
        }
        public override double Perimeter() => (sideA + sideB) * 2;
        public override double Area() => sideA * sideB;
    }
}
