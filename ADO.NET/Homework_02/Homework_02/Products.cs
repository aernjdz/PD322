using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_02
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public int SupplierID {  get; set; }

        public override string ToString()
        {
            return $"ID: {ProductID}\nName:{ProductName}\nType:{ProductType}\nSupplierID:{SupplierID}" +
                $"\n";
        }
    }
}
