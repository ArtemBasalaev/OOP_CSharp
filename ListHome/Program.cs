using System;
using System.Collections.Generic;
using System.IO;

namespace ListHome
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var linesListFromFile = GetLinesFromFile("..\\..\\..\\input.txt");

                Console.WriteLine("Результат чтения файла в список:");

                foreach (var line in linesListFromFile)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Исходный файл не найден");
                Console.WriteLine(e);
            }

            var numbersList = new List<int>(new[] { 4, 5, 6, 4, 5, 3, 2, 3 });
            Console.WriteLine("Список до удаления четных чисел:");
            Console.WriteLine(string.Join(", ", numbersList));

            RemoveEvenNumbers(numbersList);
            Console.WriteLine("Список после удаления четных чисел:");
            Console.WriteLine(string.Join(", ", numbersList));

            var numbersListWithDuplicates = new List<int>(new[] { 1, 5, 6, 9, 8, 9, 6, 8, 1, 1, 5, 6, 1, 5, 6 });
            var getListWithoutDuplicates = GetListWithoutDuplicates(numbersListWithDuplicates);

            Console.WriteLine("Список до удаления повторяющихся чисел:");
            Console.WriteLine(string.Join(", ", numbersListWithDuplicates));

            Console.WriteLine("Список после удаления повторяющихся чисел:");
            Console.WriteLine(string.Join(", ", getListWithoutDuplicates));
        }

        public static List<string> GetLinesFromFile(string filePath)
        {
            using var reader = new StreamReader(filePath);

            var list = new List<string>();
            string currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                list.Add(currentLine);
            }

            return list;
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                }
            }
        }

        public static List<int> GetListWithoutDuplicates(List<int> list)
        {
            var listWithoutDuplicates = new List<int>();

            foreach (var e in list)
            {
                if (!listWithoutDuplicates.Contains(e))
                {
                    listWithoutDuplicates.Add(e);
                }
            }

            return listWithoutDuplicates;
        }
    }
}