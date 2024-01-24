using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    class Rhombus : GeometricFigure
    {
        private double diagonal1;
        private double diagonal2;
        private double angle;

        public Rhombus(double diagonal1, double diagonal2, double angle)
        {
            this.diagonal1 = diagonal1;
            this.diagonal2 = diagonal2;
            this.angle = angle;
        }


        public override double GetArea()
        {
            return (diagonal1 * diagonal2) / 2;
        }

        public override double GetPerimeter()
        {
            return 4 * Math.Sqrt((diagonal1 * diagonal1 + diagonal2 * diagonal2) / 4 + 2 * diagonal1 * diagonal2 * Math.Cos(angle));
        }
    }
}
