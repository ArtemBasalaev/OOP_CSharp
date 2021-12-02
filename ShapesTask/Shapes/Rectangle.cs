using System;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace ShapesTask.Shapes
{
    public class Rectangle : IShape
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Значение ширины прямоугольника должно быть положительным числом, переданное значение: {value}", nameof(Width));
                }

                _width = value;
            }
        }

        public double Height
        {
            get => _height;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Значение высоты прямоугольника должно быть положительным числом, переданное значение: {value}", nameof(Height));
                }

                _height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Прямоугольник с шириной {_width:f1} и высотой {_height:f1}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var rectangle = (Rectangle)obj;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return rectangle._width == _width && rectangle._height == _height;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            var hash = prime + _width.GetHashCode();

            hash = prime * hash + _height.GetHashCode();

            return hash;
        }

        public double GetWidth()
        {
            return _width;
        }

        public double GetHeight()
        {
            return _height;
        }

        public double GetArea()
        {
            return _width * _height;
        }

        public double GetPerimeter()
        {
            return 2 * (_width + _height);
        }
    }
}