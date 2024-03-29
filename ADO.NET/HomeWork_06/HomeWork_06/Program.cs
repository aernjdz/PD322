using HomeWork_06.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicLibrary ctx = new MusicLibrary();
           ctx.Database.Initialize(true);
        }
    }
}
