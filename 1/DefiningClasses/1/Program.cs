using System;
using System.Collections.Generic;
using System.Reflection;

namespace Persons
{
    public class Person
    {
        public string name;
        public int age;

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    class ShowPerson
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<Person> olderThan30 = new List<Person>();
            
            for (int i = 0; i < number; i++)
            {
                string[] people = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string nameNewPerson = people[0];
                int ageNewPerson = int.Parse(people[1]);

                Person person = new Person(nameNewPerson, ageNewPerson);
                if (person.age > 30)
                {
                    olderThan30.Add(person);
                }                          
            }

            olderThan30.Sort((p1, p2) => p1.name.CompareTo(p2.name));

            foreach (var person in olderThan30)
            {
                Console.WriteLine("{0} - {1}", person.name, person.age);
            }
        }        
    }
}