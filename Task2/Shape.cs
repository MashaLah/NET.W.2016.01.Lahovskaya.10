using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.Configuration;

namespace Task2
{
    public abstract class Shape
    {
        private static double epsilon;

        static Shape()
        {
            try
            {
                Epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"]);
            }
            catch(TypeInitializationException exception)
            {
                Epsilon = 0.0000001;
            }
            catch (ArgumentNullException exception)
            {
                Epsilon = 0.0000001;
            }
        }

        public static double Epsilon { get;}
        abstract public double Perimeter();
        abstract public double Area();
    }

    public class Circle : Shape
    {
        private double radius;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when radius is not positive.
        /// </exception>
        /// <param name="radius">Radius of circle.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Property for radius.
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= Epsilon) throw new ArgumentException($"Parameter {nameof(radius)} must be > 0.");
                radius = value;
            }
        }
        /// <summary>
        /// Get perimeter of circle.
        /// </summary>
        /// <returns>Perimeter.</returns>
        public override double Perimeter() => 2 * PI * Radius;

        /// <summary>
        /// Get area of circle.
        /// </summary>
        /// <returns>Area.</returns>
        public override double Area() => PI * Pow(Radius, 2);
    }

    public class Triangle : Shape
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sideA">First side.</param>
        /// <param name="sideB">Second side.</param>
        /// <param name="sideC">Third side.</param>
        /// <exception cref="ArgumentException">
        /// Throws when any side is not positive.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when can't make a triangle with such sides.
        /// </exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= Epsilon || sideB <= Epsilon || sideC <= Epsilon)
                throw new ArgumentException("Every parameter must be > 0.");
            if (sideA > sideB + sideC || sideB > sideA + sideC || sideC > sideA + sideB)
                throw new ArgumentException("It is impossible to make a triangle with entered length of sides.");
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Get perimeter of triangle.
        /// </summary>
        /// <returns>Perimeter.</returns>
        public override double Perimeter() => SideA + SideB + SideC;

        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        /// <summary>
        /// Get area of triangle.
        /// </summary>
        /// <returns>Area.</returns>
        public override double Area() =>
            Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));

        /// <summary>
        /// Calculate halfperimeter.
        /// </summary>
        private double halfPerimeter => Perimeter() / 2;
    }

    public class Square : Shape 
    {
        private double side;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when side is not positive.
        /// </exception>
        /// <param name="side">Side of square.</param>
        public Square(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Property for side.
        /// </summary>
        public double Side
        {
            get { return side; }
            set
            {
                if (value <= Epsilon) throw new ArgumentException($"Parameter {nameof(side) } must be > 0.");
                side = value;
            }
        }

        /// <summary>
        /// Get perimeter of square.
        /// </summary>
        /// <returns>Perimeter.</returns>
        public override double Perimeter() => Side * 4;

        /// <summary>
        /// Get area of square.
        /// </summary>
        /// <returns>Area.</returns>
        public override double Area() => Pow(Side, 2);
    }

    public class Rectangle : Shape
    {
        private double sideA;
        private double sideB;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws when any side is not positive.
        /// </exception>
        /// <param name="sideA">First side.</param>
        /// <param name="sideB">Second side.</param>
        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        /// <summary>
        /// Property for sideA.
        /// </summary>
        public double SideA
        {
            get { return sideA; }
            set
            {
                if (value <= Epsilon) throw new ArgumentException("Every parameter must be > 0.");
                sideA = value;
            }
        }

        /// <summary>
        /// Property for sideB.
        /// </summary>
        public double SideB
        {
            get { return sideB; }
            set
            {
                if (value <= Epsilon) throw new ArgumentException("Every parameter must be > 0.");
                sideB = value;
            }
        }

        /// <summary>
        /// Get perimeter of rectangle.
        /// </summary>
        /// <returns>Perimeter.</returns>
        public override double Perimeter() => (SideA + SideB) * 2;

        /// <summary>
        /// Get area of rectangle.
        /// </summary>
        /// <returns>Area.</returns>
        public override double Area() => SideA * SideB;
    }
}
