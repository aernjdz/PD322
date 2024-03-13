using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SalesDB"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                Console.WriteLine("+----+--------------------------------------------------------------------+");
                Console.WriteLine("|  № |                             Опція                                  |");
                Console.WriteLine("+----+--------------------------------------------------------------------+");
                Console.WriteLine("|  1 | Відобразити інформацію про всіх покупців                           |");
                Console.WriteLine("|  2 | Відобразити інформацію про всіх продавців                          |");
                Console.WriteLine("|  3 | Відобразити інформацію про продажі за іменем та прізвищем продавця |");
                Console.WriteLine("|  4 | Відобразити інформацію про продажі на суму більше заданої          |");
                Console.WriteLine("|  5 | Відобразити найдорожчу та найдешевшу покупку певного покупця       |");
                Console.WriteLine("|  6 | Показати найпершу продажу певного продавця                         |");
                Console.WriteLine("|  0 | Вийти з програми                                                   |");
                Console.WriteLine("+----+--------------------------------------------------------------------+");

                Console.Write("Виберіть опцію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DisplayAllCustomers(conn);
                        break;
                    case "2":
                        Console.Clear();
                        DisplayAllSellers(conn);
                        break;
                    case "3":
                        Console.Clear();
                        DisplaySalesBySeller(conn);
                        break;
                    case "4":
                        Console.Clear();
                        DisplaySalesByAmount(conn);
                        break;
                    case "5":
                        Console.Clear();
                        DisplayMinMaxPurchaseByCustomer(conn);
                        break;
                    case "6":
                        Console.Clear();
                        DisplayFirstSaleBySeller(conn);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }

        }

        static void DisplayAllCustomers(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers;", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    Console.WriteLine("+-----+-----------------------+--------------------+");
                    Console.WriteLine("| ID  |      First Name       |       Last Name    |");
                    Console.WriteLine("+-----+-----------------------+--------------------+");

                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];

                        Console.WriteLine($"| {id,-3} | {firstName,-21} | {lastName,-18} |");

                    }

                    Console.WriteLine("+-----+-----------------------+--------------------+");
                }
            }
        }

        static void DisplayAllSellers(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sellers;", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {


                    Console.WriteLine("+-----+-----------------------+--------------------+");
                    Console.WriteLine("| ID  |      First Name       |       Last Name    |");
                    Console.WriteLine("+-----+-----------------------+--------------------+");

                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];

                        Console.WriteLine($"| {id,-3} | {firstName,-21} | {lastName,-18} |");
                    }

                    Console.WriteLine("+-----+-----------------------+--------------------+");
                }
            }
        }
        static void DisplaySalesBySeller(SqlConnection conn)
        {
            Console.Write("Введіть ім'я продавця: ");
            string firstName = Console.ReadLine();

            Console.Write("Введіть прізвище продавця: ");
            string lastName = Console.ReadLine();

          
            string query = "SELECT * FROM Sales " +
                           "INNER JOIN Sellers ON Sales.SellerID = Sellers.ID " +
                           "WHERE Sellers.FirstName = @FirstName AND Sellers.LastName = @LastName";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                 
                    if (reader.HasRows)
                    {
                        Console.WriteLine("+----------------+----------------------+-------------+------------------+--------------------+");
                        Console.WriteLine("| Sale ID        | Customer ID          | Seller ID   | Sale Amount      | Sale Date          |");
                        Console.WriteLine("+----------------+----------------------+-------------+------------------+--------------------+");

                        while (reader.Read())
                        {
                            int saleId = (int)reader["ID"];
                            int customerId = (int)reader["CustomerID"];
                            int sellerId = (int)reader["SellerID"];
                            decimal saleAmount = (decimal)reader["SaleAmount"];
                            DateTime saleDate = (DateTime)reader["SaleDate"];

                            Console.WriteLine($"| {saleId,-14} | {customerId,-20} | {sellerId,-11} | {saleAmount,-16} | {saleDate,-15} |");
                        }

                        Console.WriteLine("+----------------+----------------------+-------------+------------------+--------------------+");
                    }
                    else
                    {
                        Console.WriteLine("Продажі для вказаного продавця не знайдено.");
                    }
                }
            }
        }

        static void DisplaySalesByAmount(SqlConnection conn)
        {
            Console.Write("Введіть мінімальну суму продажу: ");
            decimal minSaleAmount;
            while (!decimal.TryParse(Console.ReadLine(), out minSaleAmount))
            {
                Console.WriteLine("Неправильні дані. Введіть дійсне десяткове число.");
                Console.Write("Введіть мінімальну суму продажу: ");
            }

        
            string query = "SELECT * FROM Sales WHERE SaleAmount > @MinSaleAmount";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@MinSaleAmount", SqlDbType.Decimal).Value = minSaleAmount;


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                  
                    if (reader.HasRows)
                    {
                        Console.WriteLine("+----------------+----------------------+-------------+------------------+--------------------+");
                        Console.WriteLine("| Sale ID        | Customer ID          | Seller ID   | Sale Amount      |    Sale Date       |");
                        Console.WriteLine("+----------------+----------------------+-------------+------------------+--------------------+");

                        while (reader.Read())
                        {
                            int saleId = (int)reader["ID"];
                            int customerId = (int)reader["CustomerID"];
                            int sellerId = (int)reader["SellerID"];
                            decimal saleAmount = (decimal)reader["SaleAmount"];
                            DateTime saleDate = (DateTime)reader["SaleDate"];

                            Console.WriteLine($"| {saleId,-14} | {customerId,-20} | {sellerId,-11} | {saleAmount,-16} | {saleDate,-15} |");
                        }

                        Console.WriteLine("+----------------+----------------------+-------------+------------------+--------------------+");
                    }
                    else
                    {
                        Console.WriteLine("Продажів на вказану суму не знайдено.");
                    }
                }
            }
        }

        static void DisplayMinMaxPurchaseByCustomer(SqlConnection conn)
        {
            Console.Write("Введіть ім'я клієнта: ");
            string firstName = Console.ReadLine();

            Console.Write("Введіть прізвище клієнта: ");
            string lastName = Console.ReadLine();

          
            string query = "SELECT MIN(SaleAmount) AS MinPurchase, MAX(SaleAmount) AS MaxPurchase " +
                           "FROM Sales " +
                           "INNER JOIN Customers ON Sales.CustomerID = Customers.ID " +
                           "WHERE Customers.FirstName = @FirstName AND Customers.LastName = @LastName";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                
                    if (reader.Read())
                    {
                        decimal minPurchase = reader.GetDecimal(reader.GetOrdinal("MinPurchase"));
                        decimal maxPurchase = reader.GetDecimal(reader.GetOrdinal("MaxPurchase"));

                        Console.WriteLine($"Мінімальна покупка: {minPurchase}");
                        Console.WriteLine($"Максимальна покупка: {maxPurchase}");
                    }
                    else
                    {
                        Console.WriteLine("Для вказаного клієнта не знайдено покупок.");
                    }
                }
            }
        }
        static void DisplayFirstSaleBySeller(SqlConnection conn)
        {
            Console.Write("Введіть ім'я продавця: ");
            string firstName = Console.ReadLine();

            Console.Write("Введіть прізвище продавця: ");
            string lastName = Console.ReadLine();

           
            string query = "SELECT TOP 1 * FROM Sales " +
                           "INNER JOIN Sellers ON Sales.SellerID = Sellers.ID " +
                           "WHERE Sellers.FirstName = @FirstName AND Sellers.LastName = @LastName " +
                           "ORDER BY SaleDate";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                 
                    if (reader.Read())
                    {
                        Console.WriteLine("+----------------+----------------+------------------+----------------------+");
                        Console.WriteLine("| Sale ID        | Customer ID    | Sale Amount      |    Sale Date         |");
                        Console.WriteLine("+----------------+----------------+------------------+----------------------+");

                        int saleId = (int)reader["ID"];
                        int customerId = (int)reader["CustomerID"];
                        decimal saleAmount = (decimal)reader["SaleAmount"];
                        DateTime saleDate = (DateTime)reader["SaleDate"];

                        Console.WriteLine($"| {saleId,-14} | {customerId,-14} | {saleAmount,-17} | {saleDate,-19} |");
                        Console.WriteLine("+----------------+----------------+------------------+----------------------+");
                    }
                    else
                    {
                        Console.WriteLine("Продажі для вказаного продавця не знайдено.");
                    }
                }
            }
        }

    }

}
