using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueStudentNames
{
    public class Student
    {
        public static HashSet<string> uniqueStudents;
        public string name;

        public Student(string name)
        {
            this.name = name;           
        }

        static Student()
        {
            uniqueStudents = new HashSet<string>();
        }
    }
    class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();

            while (!name.Equals("End"))
            {
                var Student = new Student(name);
                Student.uniqueStudents.Add(Student.name);
                name = Console.ReadLine();
            }

            Console.WriteLine(Student.uniqueStudents.Count);
        }             
    }
}
