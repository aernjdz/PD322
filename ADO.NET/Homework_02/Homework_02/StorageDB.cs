using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_02
{
    public class storageDB
    {
        private SqlConnection connection;

        public storageDB(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected to the database");
        }

        public void CreateProduct(Products product)
        {
            string cmdText = @"insert into Products
                            values(@ProductName, @ProductType, @SupplierID)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            setCommandParams(ref command, product);
            command.ExecuteNonQuery();
        }

        public List<Products> getAllProducts(SqlCommand command)
        {
            List<Products> products = new List<Products>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Products()
                {
                    ProductID = (int)reader[0],
                    ProductName = (string)reader[1],
                    ProductType = (string)reader[2],
                    SupplierID = (int)reader[3]
                });
            }
            reader.Close();
            return products;
        }

        private void setCommandParams(ref SqlCommand command, Products product)
        {
            command.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar).Value = product.ProductName;
            command.Parameters.Add("@ProductType", System.Data.SqlDbType.NVarChar).Value = product.ProductType;
            command.Parameters.Add("@SupplierID", System.Data.SqlDbType.Int).Value = product.SupplierID;
        }

        public Products getOneProduct(int ID)
        {
            string cmdText = "select * from Products where ProductID = @ProductID";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = ID;
            return getAllProducts(command).FirstOrDefault();
        }

        public List<Products> GetAll()
        {
            string cmdText = "select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            return getAllProducts(command);
        }

        public void Update(Products product)
        {
            string cmdText = @"update Products
                           set
                                ProductName = @ProductName,
                                ProductType = @ProductType,
                                SupplierID = @SupplierID
                           where ProductID = @ProductID";

            SqlCommand command = new SqlCommand(cmdText, connection);
            setCommandParams(ref command, product);
            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = product.ProductID;
            command.ExecuteNonQuery();
        }

        public void Delete(int ID)
        {
            string cmdText = @"delete from Products
                           where ProductID = @ProductID";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = ID;
            command.ExecuteNonQuery();
        }

        //  ~storageDb()
        //  {
        //      connection.Close();
        //  }




        public void CreateInventory(Inventory inventory)
        {
            string cmdText = @"insert into Inventory
                        values(@Quantity, @CostPrice)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            setCommandParamsInventory(ref command, inventory);
            command.ExecuteNonQuery();
        }


        private void setCommandParamsInventory(ref SqlCommand command, Inventory inventory)
        {
            command.Parameters.Add("@Quantity", System.Data.SqlDbType.VarChar).Value = inventory.Quantity;
            command.Parameters.Add("@CostPrice", System.Data.SqlDbType.Int).Value = inventory.CostPrice;
        }



        public List<Inventory> GetAllInventory()
        {
            string cmdText = "select * from Inventory";
            SqlCommand command = new SqlCommand(cmdText, connection);
            return getAllInventoryQuery(command);
        }

        private List<Inventory> getAllInventoryQuery(SqlCommand command)
        {
            List<Inventory> inventoryList = new List<Inventory>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                inventoryList.Add(new Inventory()
                {
                    ID = (int)reader[0],
                    Quantity = (string)reader[1],
                    CostPrice = (int)reader[2],
                });
            }
            reader.Close();
            return inventoryList;
        }




        public void CreateSupplier(Suppliers supplier)
        {
            string cmdText = @"insert into Suppliers
                        values(@SupplierName)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            setCommandParamsSupplier(ref command, supplier);
            command.ExecuteNonQuery();
        }


        private void setCommandParamsSupplier(ref SqlCommand command, Suppliers supplier)
        {
            command.Parameters.Add("@SupplierName", System.Data.SqlDbType.NVarChar).Value = supplier.Name;
        }



        public List<Suppliers> GetAllSuppliers()
        {
            string cmdText = "select * from Suppliers";
            SqlCommand command = new SqlCommand(cmdText, connection);
            return getAllSupplierQuery(command);
        }

        private List<Suppliers> getAllSupplierQuery(SqlCommand command)
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                suppliers.Add(new Suppliers()
                {
                    ID = (int)reader[0],
                    Name = (string)reader[1]
                });
            }
            reader.Close();
            return suppliers;
        }



        public void DeleteSupplier(int SupplierID)
        {
            string cmdText = @"delete from Suppliers
                           where ID = @SupplierID";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@SupplierID", System.Data.SqlDbType.Int).Value = SupplierID;
            command.ExecuteNonQuery();
        }

        public void DeleteInventory(int InventoryID)
        {
            string cmdText = @"delete from Inventory
                           where ID = @InventoryID";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@InventoryID", System.Data.SqlDbType.Int).Value = InventoryID;
            command.ExecuteNonQuery();
        }


    }
}
