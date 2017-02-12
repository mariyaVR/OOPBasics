using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
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


        public Employee(string name, decimal salary, string position, string department, string email, int age)
            : this(name, salary, position, department)
        {
            this.email = email;
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var info = new Dictionary<string, decimal>();
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

                if (newEmployee.Length >= 5)
                {
                    int num = 0;
                    bool result = Int32.TryParse(newEmployee[4], out num);
                    if (result && newEmployee.Length == 5)
                    {
                        int ageEmployee = int.Parse(newEmployee[4]);
                        employee = new Employee(nameEmployee, salaryEmployee,
                   positionEmployee, departmentEmplyee, positionEmployee, ageEmployee);
                    }
                    else if (newEmployee.Length > 5)
                    {
                        string emailEmployee = newEmployee[4];
                        int ageEmployee = int.Parse(newEmployee[5]);
                        employee = new Employee(nameEmployee, salaryEmployee,
                   positionEmployee, departmentEmplyee, emailEmployee, ageEmployee);
                    }
                    else
                    {
                        string emailEmployee = newEmployee[4];
                        int ageEmployee = -1;
                        employee = new Employee(nameEmployee, salaryEmployee,
                   positionEmployee, departmentEmplyee, emailEmployee, ageEmployee);
                    }
                }

                employees.Add(employee);

                if (!info.ContainsKey(departmentEmplyee))
                {
                    info.Add(departmentEmplyee, salaryEmployee);
                }
                else
                {
                    info[departmentEmplyee] += salaryEmployee;
                }
            }

            string maxGuid = "";
            foreach (KeyValuePair<string, decimal> entry in info)
            {
                string word = entry.Key;
                decimal val = entry.Value;
                maxGuid = info.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            }

            Console.WriteLine("Highest Average Salary: {0}", maxGuid);

            employees.Sort((p1, p2) => p2.salary.CompareTo(p1.salary));

            foreach (var empl in employees)
            {
                if (empl.department.Equals(maxGuid))
                {
                    Console.WriteLine("{0} {1:0.00} {2} {3}", empl.name, empl.salary, empl.email, empl.age);
                }
            }
        }
    }
}