using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task2
{
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
                throw new ArgumentException($"Every parameter must be > {Epsilon}.");
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
}
