using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class FigureDrawer
    {
        public static void DrawSquare(uint height, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void DrawTriangle(uint height, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
