using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    internal class Player
    {
        public List<Karta> list { get; set; } = new List<Karta>();
        public void Print()
        {
            foreach (Karta karta in list)
            {
                Console.WriteLine(karta);
            }
        }
    }
}
