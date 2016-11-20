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
}
