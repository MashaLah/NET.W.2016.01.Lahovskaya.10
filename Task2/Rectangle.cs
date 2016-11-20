using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
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
                if (value <= Epsilon) throw new ArgumentException($"Every parameter must be > {Epsilon}.");
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
                if (value <= Epsilon) throw new ArgumentException($"Every parameter must be > {Epsilon}.");
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
