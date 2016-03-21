using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    public class ShapeTriangle : Shape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        private double epsilon = 0.00001;

        public override double GetSquare()
        {
            double side1, side2, side3;

            CheckTriangle(out side1, out side2, out side3);
            double halfOfPerimetr = GetSumOfSides(side1, side2, side3) / 2;

            return Math.Sqrt(halfOfPerimetr * Math.Abs(halfOfPerimetr - side1) * Math.Abs(halfOfPerimetr - side3) * Math.Abs(halfOfPerimetr - side3));
        }

        public override double GetPerimetr()
        {
            double side1, side2, side3;

            CheckTriangle(out side1, out side2, out side3);
            return GetSumOfSides(side1, side2, side3);
        }

        private double GetSumOfSides(double side1, double side2, double side3)
        {
            return side1 + side2 + side3;
        }

        private double GetDistinity(int x0, int y0, int x1, int y1)
        {
            return Math.Sqrt(Math.Pow(x0 - x1, 2) + Math.Pow(y0 - y1, 2));
        }

        private void CheckTriangle(out double side1, out double side2, out double side3)
        {
            side1 = GetDistinity(X0, Y0, X1, Y1);
            side2 = GetDistinity(X0, Y0, X2, Y2);
            side3 = GetDistinity(X1, Y1, X2, Y2);

            if (!(CheckSide(side1, side2, side3) && CheckSide(side1, side3, side2) && CheckSide(side2, side3, side1)))
            {
                throw new Exception("This isn't a triangle");
            }
        }

        private bool CheckSide(double side1, double side2, double side3)
        {
            return side1 + side2 - side3 > epsilon;
        }
    }
}
