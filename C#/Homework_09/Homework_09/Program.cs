using System;
using System.Collections.Generic;
using System.Linq;
namespace Homework_09
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();

            employeeManager.AddEmployee(new Employee { FullName = "John Smt", Position = "Developer", Salary = 50000, Email = "john.Smt@example.com" });
            employeeManager.AddEmployee(new Employee { FullName = "Jane Smith", Position = "Manager", Salary = 60000, Email = "jane.smith@example.com" });

            Console.WriteLine("All Employees:");
            employeeManager.DisplayEmployees(employeeManager.SortEmployees(e => e.FullName));

            Console.WriteLine("\nSearch Results:");
            var searchResults = employeeManager.SearchEmployees(e => e.Salary > 55000);
            employeeManager.DisplayEmployees(searchResults);

            Employee oldEmployee = employeeManager.SearchEmployees(e => e.FullName == "John Smt").FirstOrDefault();
            if (oldEmployee != null)
            {
                Employee newEmployee = new Employee { FullName = "John Smt", Position = "Senior Developer", Salary = 65000, Email = "john.Smt@example.com" };
                employeeManager.UpdateEmployee(oldEmployee, newEmployee);
            }

            Console.WriteLine("\nUpdated Employees:");
            employeeManager.DisplayEmployees(employeeManager.SortEmployees(e => e.FullName));
        }
    }
}
