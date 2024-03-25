using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_02
{
    internal class Program
    {
       

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            storageDB db = new storageDB(ConfigurationManager.ConnectionStrings["storageDB"].ConnectionString);

            Console.WriteLine("Products::");
            db.GetAll().ForEach(p => { Console.WriteLine(p); });


            Console.WriteLine();
            Console.WriteLine("Inventory::");
            db.GetAllInventory().ForEach(p => { Console.WriteLine(p); });

            Console.WriteLine();
            Console.WriteLine("Suppliers::");
            db.GetAllSuppliers().ForEach(p => { Console.WriteLine(p); });


            Console.WriteLine();
            Console.WriteLine("Product(3):");
            Products product = db.getOneProduct(3);
            Console.WriteLine(product);


            product.ProductName = "Product0";
            product.ProductType = "Type0";
            product.SupplierID = 3;
            db.Update(product);


            Console.WriteLine();
            Console.WriteLine("Updated Product::");
            Console.WriteLine(db.getOneProduct(3));



            db.Delete(2);
            db.DeleteSupplier(2);
            db.DeleteInventory(2);





            Console.WriteLine();
            Console.WriteLine("Products::");
            db.GetAll().ForEach(p => { Console.WriteLine(p); });

            Console.WriteLine();
            Console.WriteLine("Inventory::");
            db.GetAllInventory().ForEach(p => { Console.WriteLine(p); });

            Console.WriteLine();
            Console.WriteLine("Suppliers:");
            db.GetAllSuppliers().ForEach(p => { Console.WriteLine(p); });







            Products newProduct = new Products();
            newProduct.ProductID = 4;
            newProduct.ProductName = "Name";
            newProduct.ProductType = "Type";
            newProduct.SupplierID = 3;
            db.CreateProduct(newProduct);







            Inventory newInventory = new Inventory();
            newInventory.Quantity = "Products4";
            

            db.CreateInventory(newInventory);







            Suppliers newSupplier = new Suppliers();
            newSupplier.Name = "Name";
            db.CreateSupplier(newSupplier);










            Console.WriteLine();
            Console.WriteLine("Product::");
            db.GetAll().ForEach(p => { Console.WriteLine(p); });

            Console.WriteLine();
            Console.WriteLine("Inventory:");
            db.GetAllInventory()
            .ForEach(p => { Console.WriteLine(p); });

            Console.WriteLine();
            Console.WriteLine("Suppliers:");
            db.GetAllSuppliers()
            .ForEach(p => { Console.WriteLine(p); });


        }
    }
}
