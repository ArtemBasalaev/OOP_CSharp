using System;

namespace Lambda
{
    public class Person
    {
        private readonly string _name;
        private readonly int _age;

        public string Name => _name;

        public int Age => _age;

        public Person(string name, int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException($"Значение возраста должно быть положительным числом, переданное значение age = {age}");
            }

            if (name == null)
            {
                throw new ArgumentException("Необходимо заполнить поле имя");
            }

            if (name.Length <= 1)
            {
                throw new ArgumentException($"Имя должно состоять из более чем одного символа, сейчас введено символов: {name.Length}");
            }

            _name = name;
            _age = age;
        }
    }
}