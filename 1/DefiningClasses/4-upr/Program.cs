﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_upr
{
        public class Employee
        {
            //mantadory
            public string name;
            public decimal salary;
            public string position;
            public string department;

            //optional
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

            public Employee(string name, decimal salary, string position, string department, string email)
                   : this(name, salary, position, department)
            {
                this.email = email;
            }

            public Employee(string name, decimal salary, string position, string department, int age)
                : this(name, salary, position, department)
            {
                this.age = age;
            }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
                : this(name, salary, position, department, email)
            {
                this.age = age;
            }
        }

    public class CompanyRoster
    {
        static void Main(string[] args)
        {
            int numberOfEmployess = int.Parse(Console.ReadLine());
            List<Employee> listEmployess = new List<Employee>();
            for (int i = 0; i < numberOfEmployess; i++)
            {
                string[] inputEmployee = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Employee employee = new Employee(inputEmployee[0], decimal.Parse(inputEmployee[1]),
                    inputEmployee[2], inputEmployee[3]);

                if (inputEmployee.Length == 5)
                {
                    if (inputEmployee[4].Contains("@"))
                    {
                        employee.email = inputEmployee[4];
                    }
                    else
                    {
                        employee.age = int.Parse(inputEmployee[4]);
                    }
                }
                else if (inputEmployee.Length == 6)
                {
                    employee.email = inputEmployee[4];
                    employee.age = int.Parse(inputEmployee[5]);
                }

                listEmployess.Add(employee);
            }

            var result = listEmployess
                .GroupBy(e => e.department).
                Select(e => new
                {
                    Department = e.Key,
                    Salary = e.Average(emp => emp.salary),
                    Employess = e.OrderByDescending(emp => emp.salary)
                })
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");
            foreach (var employe in result.Employess)
            {
                Console.WriteLine($"{employe.name} {employe.salary:F2} {employe.email} {employe.age}");
            }
        }        
    }
}