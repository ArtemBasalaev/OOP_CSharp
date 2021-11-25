using System;
// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Shapes.Shapes
{
    public class Square : IShape
    {
        private double _edgeLength;

        public double EdgeLength
        {
            get => _edgeLength;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Длина стороны квадрата должно быть положительным числом, переданное значение edgeLength = {value}");
                }

                _edgeLength = value;
            }
        }

        public Square(double edgeLength)
        {
            if (edgeLength <= 0)
            {
                throw new ArgumentException($"Длина стороны квадрата должна быть положительным числом, переданное значение edgeLength = {_edgeLength}");
            }

            _edgeLength = edgeLength;
        }

        public override string ToString()
        {
            return $"Квадрат со стороной {_edgeLength:f1}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            var square = (Square)obj;

            return Math.Abs(square._edgeLength - _edgeLength) < 1.0e-4;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            return prime + _edgeLength.GetHashCode();
        }

        public double GetWidth()
        {
            return _edgeLength;
        }

        public double GetHeight()
        {
            return _edgeLength;
        }

        public double GetArea()
        {
            return _edgeLength * _edgeLength;
        }

        public double GetPerimeter()
        {
            return 4 * _edgeLength;
        }
    }
}