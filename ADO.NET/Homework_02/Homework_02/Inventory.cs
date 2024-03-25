using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Homework_02
{
   public class Inventory
    {
        public int ID { get; set; }
        public string Quantity {  get; set; }
        public int CostPrice { get; set; }

        public override string ToString()
        {
            return $"ID:{ID,-5}\nQuantity:{Quantity,-5}\nCostPrice:{CostPrice,-5}\n";
        }
    }
}
