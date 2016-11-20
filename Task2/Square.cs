using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task2
{
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
                if (value <= Epsilon) throw new ArgumentException($"Parameter {nameof(side) } must be > {Epsilon}");
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
}
