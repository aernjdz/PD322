using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    public class CompoundFigure : GeometricFigure
    {
        private GeometricFigure[] figures;

       
        public CompoundFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }
        public override double GetArea()
        {
            double totalArea = 0;
            foreach (var figure in figures)
            {
                totalArea += figure.GetArea();
            }
            return totalArea;
        }

        public override double GetPerimeter()
        {
            double totalPerimeter = 0;
            foreach (var figure in figures)
            {
                totalPerimeter += figure.GetPerimeter();
            }
            return totalPerimeter;
        }
    }
}
