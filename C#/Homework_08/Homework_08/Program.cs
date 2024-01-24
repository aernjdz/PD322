using System;

namespace Homework_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Square square = new Square(4);
            Circle circle = new Circle(3);

            Rhombus rhombus = new Rhombus(5, 6, 30);
            Parallelogram parallelogram = new Parallelogram(5, 7, 30);
            Trapezoid trapezoid = new Trapezoid(5, 8, 3.5);
            Ellipse ellipse = new Ellipse(4, 2);

            CompoundFigure compoundFigure = new CompoundFigure(triangle, square, circle, rhombus, parallelogram, trapezoid, ellipse);

            Console.WriteLine("Total Area: " + compoundFigure.GetArea());
            Console.WriteLine("Total Perimeter: " + compoundFigure.GetPerimeter());
        }
    }
}
