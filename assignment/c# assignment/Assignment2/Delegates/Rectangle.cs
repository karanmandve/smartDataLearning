using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Rectangle
    {
        public delegate void MyDelegate(double width, double height);

        /// <summary>
        /// Calculate the Area of Rectangle
        /// </summary>
        public void Area(double width, double height)
        {
            Console.WriteLine($"Area of rectangle: {width * height}");
        }

        /// <summary>
        /// Calculate the Parameter of Rectangle
        /// </summary>
        public void Parameter(double width, double height)
        {
            Console.WriteLine($"Parameter of rectangle: {2 * ( width + height )}");
        }


    }
}
