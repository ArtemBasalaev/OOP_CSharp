using System;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace ShapesTask.Shapes
{
    public class Circle : IShape
    {
        private double _radius;

        public double Radius
        {
            get => _radius;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Значение радиуса должно быть положительным числом, переданное значение r = {value:f1}");
                }

                _radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Окружность с радиусом {_radius}";
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

            var circle = (Circle)obj;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return circle._radius == _radius;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            return prime + _radius.GetHashCode();
        }

        public double GetWidth()
        {
            return 2 * _radius;
        }

        public double GetHeight()
        {
            return 2 * _radius;
        }

        public double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}