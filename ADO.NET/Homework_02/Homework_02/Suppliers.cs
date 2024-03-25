using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_02
{
    public class Suppliers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"ID:{ID,-5}\nName:{Name,-5}\n";
        }
    }
}
