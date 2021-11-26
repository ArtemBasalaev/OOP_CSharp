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
                    throw new ArgumentException($"Значение ширины прямоугольника должно быть положительным числом, переданное значение width = {value}");
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
                    throw new ArgumentException($"Значение высоты прямоугольника должно быть положительным числом, переданное значение height = {value}");
                }

                _height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException($"Значение ширины прямоугольника должно быть положительным числом, переданное значение width = {width}");
            }

            if (height <= 0)
            {
                throw new ArgumentException($"Значение высоты прямоугольника должно быть положительным числом, переданное значение height = {height}");
            }

            _width = width;
            _height = height;
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

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            var rectangle = (Rectangle)obj;

            return Math.Abs(rectangle.GetWidth() - _width) < 1e-4 && Math.Abs(rectangle.GetHeight() - _height) < 1.0e-4;
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