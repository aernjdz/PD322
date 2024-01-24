using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class Parallelogram : GeometricFigure
    {
        private double baseLength;
        private double height;
        private double angle;

        public Parallelogram(double baseLength, double height, double angle)
        {
            this.baseLength = baseLength;
            this.height = height;
            this.angle = angle;
        }

        public override double GetArea()
        {
            return baseLength * height;
        }

        public override double GetPerimeter()
        {
            return 2 * (baseLength + height / Math.Sin(angle));
        }
    }
}
