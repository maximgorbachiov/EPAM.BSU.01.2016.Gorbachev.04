using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace ShapeHierarchy
{
    public class ShapeEllipse : Shape
    {
        public int RadiusA { get; set; }
        public int RadiusB { get; set; }

        public ShapeEllipse(int x, int y, int radiusA, int radiusB)
        {
            X0 = x;
            Y0 = y;
            RadiusA = radiusA;
            RadiusB = radiusB;
        }

        public override double GetSquare()
        {
            return Math.PI * RadiusA * RadiusB;
        }

        public override double GetPerimetr()
        {
            return 4*(GetSquare() + Math.Pow(RadiusA - RadiusB, 2)) / (RadiusA + RadiusB);
        }
    }
}
