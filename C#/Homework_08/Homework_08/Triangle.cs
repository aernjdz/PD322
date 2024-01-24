using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Triangle : GeometricFigure
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double a, double b, double c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }
        public override double GetArea()
        {
            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }
        public override double GetPerimeter()
        {
            return sideA + sideB + sideC;
        }
    }

}
