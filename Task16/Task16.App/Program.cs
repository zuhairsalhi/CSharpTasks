using System;
using System.Collections.Generic;
using System.Linq;

namespace Task16.App
{



        class Program
        {
            static void Main()
            {
                List<Person> people = new List<Person>
            {
                new Person("Zuhair", 24, "Amman"),
                new Person("Ahmad", 30, "Irbid"),
                new Person("Omar", 22, "Amman"),
                new Person("Khaled", 35, "Zarqa"),
                new Person("Ali", 28, "Amman")
            };

              
                Console.WriteLine(" All People ");

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine();
                Console.WriteLine(" People Older Than 25 ");

                var olderPeople = people.Where(person => person.Age > 25);

                foreach (Person person in olderPeople)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine();
                Console.WriteLine("People From Amman");

                var ammanPeople = people.Where(person => person.City == "Amman");

                foreach (Person person in ammanPeople)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine();
                Console.WriteLine("Sorted By Age");

                var sortedPeople = people.OrderBy(person => person.Age);

                foreach (Person person in sortedPeople)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine();
                Console.WriteLine(" Sorted By Age Descending ");

                var oldestFirst = people.OrderByDescending(person => person.Age);

                foreach (Person person in oldestFirst)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine();
                Console.WriteLine("Names");

                var names = people.Select(person => person.Name);

                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }

                Console.WriteLine();
                Console.WriteLine(" First Person From Amman ");

                var firstAmmanPerson =
                    people.FirstOrDefault(person => person.City == "Amman");

                if (firstAmmanPerson != null)
                {
                    Console.WriteLine(firstAmmanPerson);
                }

                Console.WriteLine();
                Console.WriteLine(" Count");

                int count = people.Count();

                Console.WriteLine($"Total people: {count}");

                Console.WriteLine();
                Console.WriteLine(" Any ");

                bool hasPersonOver40 = people.Any(person => person.Age > 40);

                Console.WriteLine($"Anyone older than 40: {hasPersonOver40}");

                Console.WriteLine();
                Console.WriteLine(" Average Age ");

                double averageAge = people.Average(person => person.Age);

                Console.WriteLine($"Average age: {averageAge}");
            }
        }
    }
