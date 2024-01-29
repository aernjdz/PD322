using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    class Monitor : IPrintInformation
    {
        private string name;

        public Monitor(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void Print(string str)
        {
            Console.WriteLine($"Displaying on {GetName()}: {str}");
        }

        public string GetInfo()
        {
            return $"Monitor Info: Name - {GetName()}";
        }

        public override string ToString()
        {
            return $"{GetName()}: {GetInfo()}";
        }
    }
}
