using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace Homework_04
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSite myWebsite = new WebSite();
            myWebsite.InputData();
            Console.WriteLine("\nWebsite Information:");
            myWebsite.DisplayData();

            Magazine myMagazine = new Magazine();
            myMagazine.InputData();

            Console.WriteLine("\nMagazine Information:");
            myMagazine.DisplayData();

            Store myStore = new Store();
            myStore.InputData();

            Console.WriteLine("\nStore Information:");
            myStore.DisplayData();

        }
    }
}
