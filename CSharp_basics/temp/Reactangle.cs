using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    public class Reactangle
    {
        public int Width;
        public int Height;
        private static int Value = 1;

        public static int CountOfObjects;

        public Reactangle(int width, int height)
        {
            Width = width;
            Height = height;
            CountOfObjects++;
        }

        public string GetValue() => $"value : {Value}";
    }
}
