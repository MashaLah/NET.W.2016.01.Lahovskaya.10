using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;
using System.Collections;

namespace Task2Tests
{
    [TestFixture]
    public class ShapeTests
    {
        /// <summary>
        /// A test for Circle constructor.
        /// </summary>
        [Test]
        public void Constructor_InvalidData_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-5));
        }

        /// <summary>
        /// A test for Perimeter.
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesPerimeter))]
        public void Perimeter_ReternValidPerimeter(IShape obj, double expected)
        {
            Assert.AreEqual(obj.Perimeter, expected);
        }

        /// <summary>
        /// A test for Area.
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesArea))]
        public void Area_ReternValidArea(IShape obj, double expected)
        {
            Assert.AreEqual(obj.Area, expected);
        }

        /// <summary>
        /// Test cases for Perimeter/
        /// </summary>
        static IEnumerable ValidTestCasesPerimeter
        {
            get
            {
                yield return new TestCaseData(new Circle(3), 6 * Math.PI);
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
                yield return new TestCaseData(new Circle(3), 9*Math.PI);
                yield return new TestCaseData(new Rectangle(3, 2), 6);
                yield return new TestCaseData(new Triangle(3, 3, 4),Math.Sqrt(20));
                yield return new TestCaseData(new Square(3), 9);
            }
        }
    }
}
