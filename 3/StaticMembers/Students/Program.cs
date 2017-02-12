using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        public class Student
        {
            public static int studentInstances = 0;

            public string name;

            public Student(string name)
            {
                this.name = name;
                studentInstances++;
            }
        }
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            while (!name.Equals("End"))
            {
                var Student = new Student(name);
                name = Console.ReadLine();
            }

            Console.WriteLine(Student.studentInstances);
        }
    }
}
