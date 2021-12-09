using System;
using System.Collections.Generic;

namespace ListTask
{
    public class Program
    {
        public static void Main()
        {
            var list = new MyList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Созданный список:");
            Console.WriteLine(list);
            Console.WriteLine($"Длина списка = {list.Count}");

            Console.WriteLine($"Значение элемента по индексу: list[5] = {list[5]}");

            list[5] = 5;
            Console.WriteLine("Список после установки значения по индексу: list[5] = 5");
            Console.WriteLine(list);

            list.Add(11);
            Console.WriteLine("Список после добавления элемента в конец:");
            Console.WriteLine(list);
            Console.WriteLine($"Длина списка = {list.Count}");

            list.Insert(0, 1071);
            Console.WriteLine("Список после добавления элемента по индексу [0]:");
            Console.WriteLine(list);
            Console.WriteLine($"Длина списка = {list.Count}");

            list.RemoveAt(0);
            Console.WriteLine("Список после удаления элемента по индексу [0]:");
            Console.WriteLine(list);
            Console.WriteLine($"Длина списка = {list.Count}");

            if (list.Contains(1071))
            {
                Console.WriteLine("Список содержит переданный элемент");
            }
            else
            {
                Console.WriteLine("Список не содержит переданный элемент со значением 1071");
            }

            Console.WriteLine("Проход итератором по списку:");

            foreach (var e in list)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();

            Console.WriteLine($"Значение свойства Capacity = {list.Capacity}");
            list.Capacity = 50;
            Console.WriteLine($"Значение свойства Capacity, после его увеличения = {list.Capacity}");

            var array = new int[30];
            list.CopyTo(array, 5);

            Console.WriteLine("Список скопированный в массив:");
            Console.WriteLine(string.Join(", ", array));

            list.Clear();
            Console.Write($"Список после очистки: {list}");
        }
    }
}