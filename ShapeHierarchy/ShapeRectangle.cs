using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    public class ShapeRectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public ShapeRectangle(int x, int y, int height, int width)
        {
            X0 = x;
            Y0 = y;
            Height = height;
            Width = width;
        }

        public override double GetSquare()
        {
            return Height * Width;
        }

        public override double GetPerimetr()
        {
            return 2 * Height + 2 * Width;
        }
    }
}
