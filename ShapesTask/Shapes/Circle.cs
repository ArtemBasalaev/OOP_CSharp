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
                    throw new ArgumentException($"Значение радиуса должно быть положительным числом, переданное значение r = {_radius:f1}");
                }

                _radius = value;
            }
        }

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException($"Значение радиуса должно быть положительным числом, переданное значение r = {_radius:f1}");
            }

            _radius = radius;
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

            return Math.Abs(circle.Radius - _radius) < 1.0e-4;
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