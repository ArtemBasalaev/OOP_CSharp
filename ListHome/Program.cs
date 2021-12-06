﻿using System;
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
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Указанная директория не найдена");
                Console.WriteLine(e);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Путь или полное имя файла длиннее, чем максимальная длина, определенная системой");
                Console.WriteLine(e);
            }
            catch (IOException e)
            {
                Console.WriteLine("Ошибка при работе с файлом. Подробную информацию можно получить из стека вызовов");
                Console.WriteLine(e);
            }

            var numbersList = new List<int> { 4, 5, 6, 4, 5, 3, 2, 3 };
            Console.WriteLine("Список до удаления четных чисел:");
            Console.WriteLine(string.Join(", ", numbersList));

            RemoveEvenNumbers(numbersList);
            Console.WriteLine("Список после удаления четных чисел:");
            Console.WriteLine(string.Join(", ", numbersList));

            var numbersListWithDuplicates = new List<int> { 1, 5, 6, 9, 8, 9, 6, 8, 1, 1, 5, 6, 1, 5, 6 };
            var numbersListWithoutDuplicates = GetListWithoutDuplicates(numbersListWithDuplicates);

            Console.WriteLine("Список до удаления повторяющихся чисел:");
            Console.WriteLine(string.Join(", ", numbersListWithDuplicates));

            Console.WriteLine("Список после удаления повторяющихся чисел:");
            Console.WriteLine(string.Join(", ", numbersListWithoutDuplicates));
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
            var numbersListWithoutDuplicates = new List<int>(list.Count);

            foreach (var e in list)
            {
                if (!numbersListWithoutDuplicates.Contains(e))
                {
                    numbersListWithoutDuplicates.Add(e);
                }
            }

            return numbersListWithoutDuplicates;
        }
    }
}