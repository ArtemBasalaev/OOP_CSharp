using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda
{
    public class Program
    {
        public static void Main()
        {
            var persons = new LinkedList<Person>(new[]
            {
                new Person("Ivan", 25),
                new Person("Ivan", 13),
                new Person("Denis", 30),
                new Person("Sergey", 22),
                new Person("Pyotr", 12),
                new Person("Anton", 43)
            });

            //А
            var uniqueNamesList = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            //Б
            var uniqueNamesString = string.Join(", ", uniqueNamesList);

            Console.WriteLine("В списке содержатся следующие уникальные имена:");
            Console.WriteLine($"Имена: {uniqueNamesString}.");

            //В
            const int limitAge = 18;

            var personsYoungerThanLimitAge = persons
                .Where(p => p.Age < limitAge)
                .ToList();

            var averageAge = personsYoungerThanLimitAge
                .Select(p => p.Age)
                .Average();

            Console.WriteLine($"Средний возраст людей младше 18: {averageAge}");

            //Г
            var averageAgeByName = persons
                .GroupBy(p => p.Name)
                .ToDictionary(group => group.Key, group => group.ToList().Select(p => p.Age).Average());

            Console.WriteLine("Средний возраст людей, имеющих одинаковое имя:");
            Console.WriteLine(string.Join(", ", averageAgeByName));

            //Д
            const int minAge = 20;
            const int maxAge = 45;

            var personsInRangeAges = persons
                .Where(p => p.Age >= minAge && p.Age <= maxAge)
                .ToList();

            var personsNamesDescendingByAge = personsInRangeAges
                .OrderByDescending(p => p.Age)
                .Select(p => p.Name)
                .ToArray();

            Console.WriteLine($"Список людей возраст, которых находится в диапазоне от {minAge} до {maxAge}, в порядке убывания их возраста: ");
            Console.Write(string.Join(", ", personsNamesDescendingByAge));
        }
    }
}