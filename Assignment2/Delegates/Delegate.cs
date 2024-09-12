using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Delegate
    {
        // delegate define
        public delegate int MyDelegate(int x, int y);

        // performing operation on delegate
        public static int OperationToPerform(MyDelegate operation, int x, int y)
        {
            return operation(x, y);
        }

        // perform multiplication of two number
        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        // perform substraction of two number
        public static int Substract(int x, int y)
        {
            return x - y;
        }

    }
}
