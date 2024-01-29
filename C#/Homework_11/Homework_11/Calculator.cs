using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class Calculator
    {
        private Func<double, double, double> func;

        public void SetOperation(Operation op)
        {
            switch (op)
            {
                case Operation.Plus:
                    func = (x, y) => x + y;
                    break;
                case Operation.Minus:
                    func = (x, y) => x - y;
                    break;
                case Operation.Mult:
                    func = (x, y) => x * y;
                    break;
                case Operation.Div:
                    func = (x, y) =>
                    {
                        if (y != 0)
                            return x / y;
                        else
                        {
                            Console.WriteLine("Division by zero is not allowed!");
                            return double.NaN; 
                        }
                    };
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    break;
            }
        }

        public double Calculate(double one, double two)
        {
            if (func != null)
                return func(one, two);
            else
            {
                Console.WriteLine("Operation is not set!");
                return double.NaN; 
            }
        }
    }
}
