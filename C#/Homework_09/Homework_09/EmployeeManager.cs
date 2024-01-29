using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_09
{
    class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public void UpdateEmployee(Employee oldEmployee, Employee newEmployee)
        {
            int index = employees.IndexOf(oldEmployee);
            if (index != -1)
            {
                employees[index] = newEmployee;
            }
        }

        public List<Employee> SearchEmployees(Func<Employee, bool> predicate)
        {
            return employees.Where(predicate).ToList();
        }

        public List<Employee> SortEmployees(Func<Employee, IComparable> keySelector)
        {
            return employees.OrderBy(keySelector).ToList();
        }

        public void DisplayEmployees(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                Console.WriteLine($"Name: {employee.FullName}, Position: {employee.Position}, Salary: {employee.Salary}, Email: {employee.Email}");
            }
        }
    }
}

