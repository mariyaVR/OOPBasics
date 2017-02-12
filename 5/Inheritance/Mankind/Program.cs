using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankind //not correct constraints in the assignment
{
    public class Human
    {
        private string firstName;
        private string secondName;

        public Human(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public virtual string SecondName
        {
            get { return this.secondName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                this.secondName = value;
            }
        }
    }

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string secondName, string facultyNumber)
            : base(firstName, secondName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public override string FirstName
        {
            get { return base.FirstName; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                    }
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Name: ").Append(this.FirstName)
              .Append(Environment.NewLine)
              .Append("Last Name: ").Append(this.SecondName)
              .Append(Environment.NewLine)
              .Append("Faculty number: ").Append(this.FacultyNumber);
            return sb.ToString();
        }
    }
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string secondName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, secondName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        private decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        private double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        private double PayPerHour()
        {
            var payPerDay = this.WeekSalary / 5;
            var payPerHour = (double)payPerDay / this.WorkHoursPerDay;
            return payPerHour;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Name: ").Append(this.FirstName)
                .Append(Environment.NewLine)
                .Append("Last Name: ").Append(this.SecondName)
                .Append(Environment.NewLine)
                .Append("Week Salary: ").Append($"{this.WeekSalary:F2}")
                .Append(Environment.NewLine)
                .Append("Hours per day: ").Append($"{this.WorkHoursPerDay:F2}")
                .Append(Environment.NewLine)
                .Append("Salary per hour: ").Append($"{this.PayPerHour():F2}");
            return sb.ToString();
        }
    }

    public class Mankind
    {
        public static void Main()
        {
            string[] studentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string studentFirstName = studentInfo[0];
            string studentSecondName = studentInfo[1];
            string facultyNumber = studentInfo[2];

            String[] workerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string workerFirstName = workerInfo[0];
            string workerSecondName = workerInfo[1];
            decimal workerWeekSalary = decimal.Parse(workerInfo[2]);
            double workerHoursPerDay = double.Parse(workerInfo[3]);
            try
            {
                Student student = new Student(studentFirstName, studentSecondName, facultyNumber);
                Worker worker = new Worker(workerFirstName, workerSecondName, workerWeekSalary, workerHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

