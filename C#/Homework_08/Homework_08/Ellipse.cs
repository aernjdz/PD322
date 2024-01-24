using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Ellipse : GeometricFigure
    {
        private double semiMajorAxis;
        private double semiMinorAxis;

        public Ellipse(double semiMajorAxis, double semiMinorAxis)
        {
            this.semiMajorAxis = semiMajorAxis;
            this.semiMinorAxis = semiMinorAxis;
        }

        public override double GetArea()
        {
            return Math.PI * semiMajorAxis * semiMinorAxis;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Math.Sqrt((semiMajorAxis * semiMajorAxis + semiMinorAxis * semiMinorAxis) / 2);
        }
    }
}
