using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2
{
    public class Employee
    {
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < number; i++)
            {
                string[] newEmployee = Console.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string nameEmployee = newEmployee[0];
                decimal salaryEmployee = decimal.Parse(newEmployee[1]);
                string positionEmployee = newEmployee[2];
                string departmentEmplyee = newEmployee[3];

                Employee employee = new Employee(nameEmployee, salaryEmployee,
                    positionEmployee, departmentEmplyee);

                if (newEmployee.Length > 4)
                {
                    var ageOrEmail = newEmployee[4];
                    if (ageOrEmail.Contains("@"))
                    {
                        employee.email = ageOrEmail;
                    }
                    else
                    {
                        employee.age = int.Parse(ageOrEmail);
                    }
                }

                if (newEmployee.Length > 5)
                {
                    employee.age = int.Parse(newEmployee[5]);
                }

                employees.Add(employee);
            }

            var result = employees
                .GroupBy(e => e.department)
                .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.salary),
                Employees = e.OrderByDescending(emp => emp.salary)
            })
            .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");

            foreach (var employee in result.Employees)
            {
                Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
            }
        }
    }
}