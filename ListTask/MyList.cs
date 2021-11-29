using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
                if (_elements.Length < value)
                {
                    Array.Resize(ref _elements, value);
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
                throw new ArgumentException($"Вместимость списка не может быть отрицательным числом, передано значение capacity = {capacity}");
            }

            _elements = new T[capacity];
        }

        public MyList(T[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException("Передана пустая ссылка");
            }

            _elements = (T[])array.Clone();
            Count = array.Length;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException($"Выход за границы списка. Допустимый диапазон индекса 0 <= index < {index}, передан index = {index}");
            }
        }

        private void IncreaseCapacity()
        {
            var newCapacity = _elements.Length > 0 ? _elements.Length * 2 : DefaultCapacity;

            Array.Resize(ref _elements, newCapacity);
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
                sb.Append(_elements[i])
                    .Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');

            return sb.ToString();
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
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
                if (_elements[i].Equals(list._elements[i]))
                {
                    return false;
                }
            }

            return true;
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            const int prime = 37;
            var hash = 1;

            for (var i = 0; i < Count; i++)
            {
                hash = prime * hash + _elements[i].GetHashCode();
            }

            return hash;
        }

        public void TrimToSize()
        {
            if (_elements.Length > Count)
            {
                Array.Resize(ref _elements, Count);
            }
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

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void Insert(int index, T item)
        {
            if (index != Count)
            {
                CheckIndex(index);
            }

            if (_elements.Length == Count)
            {
                IncreaseCapacity();
            }

            Array.ConstrainedCopy(_elements, index, _elements, index + 1, Count - index);

            _elements[index] = item;

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

        public bool Remove(T item)
        {
            int index = IndexOf(item);

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
                Array.ConstrainedCopy(_elements, index + 1, _elements, index, Count - index - 1);
            }

            Array.Clear(_elements, Count - 1, 1);

            Count--;
            _modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_elements, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new NullReferenceException("Передана пустая ссылка");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException($"Выход за границы массива. Допустимый диапазон индекса 0 <= arrayIndex < {array.Length}," +
                                                      $" передан arrayIndex = {arrayIndex}");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("В массиве недостаточно места для копирования коллекции");
            }

            Array.ConstrainedCopy(_elements, 0, array, arrayIndex, Count);
        }
    }
}