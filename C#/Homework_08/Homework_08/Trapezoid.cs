using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Trapezoid : GeometricFigure
    {
        private double base1;
        private double base2;
        private double height;

      
        public Trapezoid(double base1, double base2, double height)
        {
            this.base1 = base1;
            this.base2 = base2;
            this.height = height;
        }

      
        public override double GetArea()
        {
            return (base1 + base2) * height / 2;
        }

        public override double GetPerimeter()
        {
            double sideA = Math.Abs(base2 - base1) / 2;
            double sideB = Math.Sqrt(height * height + sideA * sideA);
            return base1 + base2 + 2 * sideB;
        }
    }
}
