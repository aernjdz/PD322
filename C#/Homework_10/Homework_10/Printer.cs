using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    class Printer : IPrintInformation
    {
        private string memory;
        private int pageCount;

        public Printer(string memory, int pageCount)
        {
            this.memory = memory;
            this.pageCount = pageCount;
        }

        public string GetName()
        {
            return "Printer";
        }

        public void Print(string str)
        {
            Console.WriteLine($"Printing from {GetName()}: {str}");
        }

        public string GetInfo()
        {
            return $"Printer Info: Memory - {memory}, Page Count - {pageCount}";
        }

        public override string ToString()
        {
            return $"{GetName()}: {GetInfo()}";
        }
    }
}
