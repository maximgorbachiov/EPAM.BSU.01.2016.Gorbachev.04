using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy
{
    public abstract class Shape : ShapePoint
    {
        public abstract double GetSquare();
        public abstract double GetPerimetr();
    }
}
