using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;
using System.Collections;
using static System.Math;

namespace Task2Tests
{
    [TestFixture]
    public class ShapeTests
    {
        /// <summary>
        /// A test for Circle constructor.
        /// </summary>
        [TestCase(-5)]
        [TestCase(0)]
        public void ConstructorCircle_InvalidData_Exception(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        /// <summary>
        /// A test for Triangle constructor.
        /// </summary>
        [TestCase(-5, 3, 4)]
        [TestCase(3, -5, 4)]
        [TestCase(4, 3, -5)]
        [TestCase(0, 3, 4)]
        [TestCase(3, 0, 4)]
        [TestCase(4, 3, 0)]
        [TestCase(1, 13, 4)]
        [TestCase(13, 1, 4)]
        [TestCase(4, 1, 13)]
        public void ConstructorTriangle_InvalidData_Exception(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        /// <summary>
        /// A test for Rectangle constructor.
        /// </summary>
        [TestCase(-5, 3)]
        [TestCase(3, -5)]
        [TestCase(0, 3)]
        [TestCase(3, 0)]
        public void ConstructorRectangle_InvalidData_Exception(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(a, b));
        }

        /// <summary>
        /// A test for Square constructor.
        /// </summary>
        [TestCase(-5)]
        [TestCase(0)]
        public void ConstructorSquare_InvalidData_Exception(double a)
        {
            Assert.Throws<ArgumentException>(() => new Square(a));
        }

        /// <summary>
        /// A test for Perimeter.
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesPerimeter))]
        public void Perimeter_ReternValidPerimeter(Shape obj, double expected)
        {
            Assert.AreEqual(obj.Perimeter(), expected);
        }

        /// <summary>
        /// A test for Area.
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesArea))]
        public void Area_ReternValidArea(Shape obj, double expected)
        {
            obj.Area();
            Assert.AreEqual(obj.Area(), expected);
        }

        /// <summary>
        /// Test cases for Perimeter/
        /// </summary>
        static IEnumerable ValidTestCasesPerimeter
        {
            get
            {
                yield return new TestCaseData(new Circle(3), 6 * PI);
                yield return new TestCaseData(new Rectangle(3,2),10);
                yield return new TestCaseData(new Triangle(3,2,4),9);
                yield return new TestCaseData(new Square(3),12);
            }
        }

        /// <summary>
        /// Test cases for Area.
        /// </summary>
        static IEnumerable ValidTestCasesArea
        {
            get
            {
                yield return new TestCaseData(new Circle(3), 9 * PI);
                yield return new TestCaseData(new Rectangle(3, 2), 6);
                yield return new TestCaseData(new Triangle(3, 3, 4), Sqrt(20));
                yield return new TestCaseData(new Square(3), 9);
            }
        }
    }
}
