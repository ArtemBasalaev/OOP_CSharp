using System;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace ShapesTask.Shapes
{
    public class Square : IShape
    {
        private double _sideLength;

        public double SideLength
        {
            get => _sideLength;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Длина стороны квадрата должно быть положительным числом, переданное значение sideLength = {value}");
                }

                _sideLength = value;
            }
        }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public override string ToString()
        {
            return $"Квадрат со стороной {_sideLength:f1}";
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

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return square._sideLength == _sideLength;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            return prime + _sideLength.GetHashCode();
        }

        public double GetWidth()
        {
            return _sideLength;
        }

        public double GetHeight()
        {
            return _sideLength;
        }

        public double GetArea()
        {
            return _sideLength * _sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * _sideLength;
        }
    }
}