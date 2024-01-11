using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public interface IShapeLSP
    {
        int CalculateArea();

    }

    public class Rectangle : IShapeLSP
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void SetWidth(int width)
        {
            Width = width;
        }

        public virtual void SetHeight(int height)
        {
            Height = height;
        }

        public int CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Square : IShapeLSP
    {
        public int Side { get; set; }

        public void SetSide(int side)
        {
            Side = side;
        }

        public int CalculateArea()
        {
            return Side * Side;
        }

    }
}
