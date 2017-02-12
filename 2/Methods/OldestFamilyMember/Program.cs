using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OldestFamilyMember
{
    public class Person
    {
        public string name;
        public int age;
        
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    public class Family
    {
        public List<Person> listOfFamily;

        public void AddMember(Person member)
        {
            listOfFamily.Add(member);
        }

        public Person GetOldestMember()
        {
            return listOfFamily
                .OrderByDescending(p => p.age)
                .First();
        }
    }
    class Startup
    {
        static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            family.listOfFamily = new List<Person>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                family.listOfFamily.Add(person);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.name} {oldestMember.age}");
        }
    }
}