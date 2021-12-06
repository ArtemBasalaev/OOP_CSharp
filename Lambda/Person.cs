using System;

namespace Lambda
{
    public class Person
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Person(string name, int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException($"Значение возраста должно быть положительным числом, переданное значение: {age}", nameof(age));
            }

            if (name == null)
            {
                throw new ArgumentException("Необходимо заполнить поле имя", nameof(name));
            }

            if (name.Length <= 1)
            {
                throw new ArgumentException($"Имя должно состоять из более чем одного символа, сейчас введено символов: {name.Length}", nameof(name));
            }

            Name = name;
            Age = age;
        }
    }
}