using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace ListTask
{
    public class MyList<T> : IList<T>
    {
        private const int DefaultCapacity = 10;

        private T[] _elements;
        private int _modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return _elements[index];
            }

            set
            {
                CheckIndex(index);

                _elements[index] = value;
            }
        }

        public int Capacity
        {
            get => _elements.Length;

            set
            {
                if (Count > value)
                {
                    throw new ArgumentOutOfRangeException(nameof(Capacity), "Для свойства установлено значение, которое меньше чем значение свойства Count");
                }

                if (value == _elements.Length)
                {
                    return;
                }

                if (Count < value)
                {
                    var newElements = new T[value];

                    Array.Copy(_elements, newElements, Count);

                    _elements = newElements;
                }
            }
        }

        public MyList()
        {
            _elements = new T[DefaultCapacity];
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Вместимость списка не может быть отрицательным числом, передано значение: {capacity}", nameof(capacity));
            }

            _elements = new T[capacity];
        }

        public MyList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Передана пустая ссылка");
            }

            _elements = (T[])array.Clone();
            Count = array.Length;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Выход за границы списка. Допустимый диапазон индекса 0 <= index < {Count}, передано значение: {index}");
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            var sb = new StringBuilder();
            sb.Append('[');

            for (var i = 0; i < Count; i++)
            {
                sb.Append(_elements[i]).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var list = (MyList<T>)obj;

            if (Count != list.Count)
            {
                return false;
            }

            for (var i = 0; i < Count; i++)
            {
                if (Equals(_elements[i], list._elements[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            var hash = 1;

            for (var i = 0; i < Count; i++)
            {
                hash = prime * hash + (_elements[i] != null ? _elements[i].GetHashCode() : 0);
            }

            return hash;
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var savedModCount = _modCount;

            for (var i = 0; i < Count; i++)
            {
                if (savedModCount != _modCount)
                {
                    throw new InvalidOperationException("Коллекция изменилась");
                }

                yield return _elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T element)
        {
            Insert(Count, element);
        }

        public void Insert(int index, T element)
        {
            if (index != Count)
            {
                CheckIndex(index);
            }

            if (_elements.Length == Count)
            {
                Capacity = _elements.Length > 0 ? _elements.Length * 2 : DefaultCapacity;
            }

            Array.Copy(_elements, index, _elements, index + 1, Count - index);

            _elements[index] = element;

            Count++;
            _modCount++;
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(_elements, 0, Count);

            Count = 0;
            _modCount++;
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (index < Count - 1)
            {
                Array.Copy(_elements, index + 1, _elements, index, Count - index - 1);
            }

            _elements[Count - 1] = default;

            Count--;
            _modCount++;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(_elements, element, 0, Count);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Передана пустая ссылка");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Выход за границы массива. Допустимый диапазон индекса 0 <= arrayIndex < {array.Length}, передано значение: {arrayIndex}");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException($"В массиве недостаточно места для копирования коллекции, передано значение: {arrayIndex}", nameof(arrayIndex));
            }

            Array.Copy(_elements, 0, array, arrayIndex, Count);
        }
    }
}