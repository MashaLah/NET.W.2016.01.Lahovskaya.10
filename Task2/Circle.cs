using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Task2
{
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
                if (value <= Epsilon) throw new ArgumentException($"Parameter {nameof(radius)} must be > {Epsilon}");
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
}
