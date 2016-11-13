using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task2
{
    public interface IShape
    {
        double Perimeter { get; }
        double Area { get; }
    }

    public class Circle : IShape
    {
        private double radius;
       // public double Radius { get; set; }
        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException($"Parameter {nameof(radius)} must be > 0.");
            this.radius = radius;
        }
        public double Perimeter
        {
            get {return 2 * PI * radius; }
        }
        public double Area
        {
            get { return PI * Pow(radius, 2); }
        }
    }

    public class Triangle : IShape
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
        public double Perimeter
        {
            get { return sideA + sideB + sideC; }
        }
        public double Area
        {
            get { return Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC)); }
        }
        private double halfPerimeter => Perimeter / 2;
    }

    public class Square : IShape 
    {
        private double side;
        //public double Side { get; set; }
        public Square(double side)
        {
            if (side <= 0) throw new ArgumentException($"Parameter {nameof(side) } must be > 0.");
            this.side = side;
        } 
        public double Perimeter
        {
            get { return side * 4; }
        }
        public double Area
        {
            get { return Pow(side, 2); }
        }
    }

    public class Rectangle : IShape
    {
        private double sideA;
        private double sideB;
        //public double SideA { get; set; }
        //public double SideB { get; set; }
        public Rectangle(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0) throw new ArgumentException("Every parameter must be > 0.");
            this.sideA = sideA;
            this.sideB = sideB;
        }
        public double Perimeter
        {
            get { return (sideA + sideB) * 2; }
        }
        public double Area
        {
            get { return sideA * sideB; }
        }
    }
}
