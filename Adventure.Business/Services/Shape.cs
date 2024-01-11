using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public abstract class Shape
    {
        public abstract int CalculateArea();
    }

    public class RectangleSolid : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int CalculateArea()
        {
            return Width * Height;
        }
    }

    public class SquareSolid : Shape
    {
        public int SideLength { get; set; }

        public override int CalculateArea()
        {
            return SideLength * SideLength;
        }
    }
}
