using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07

{
    class Director : ICloneable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Director(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public object Clone()
        {
            return new Director(Name, LastName);
        }
        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}