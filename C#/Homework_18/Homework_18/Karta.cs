using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18
{
    internal class Karta
    {
        public uint Priory { get; set; }
        public string Suit { get; set; }
        public string Number { get; set; }

        public Karta(string suit,string number, uint pr = 0)
        {
            Priory = pr;
            Suit = suit;
            Number = number;
        }
        public override string ToString()
        {
            return $"{Number} {Suit}";
        }
    }
}
