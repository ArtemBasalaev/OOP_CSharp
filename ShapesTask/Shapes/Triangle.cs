using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace ShapesTask.Shapes
{
    class Triangle : IShape
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        private double _x3;
        private double _y3;

        public double X1
        {
            get => _x1;

            set
            {
                CheckTriangle(value, _y1, _x2, _y2, _x3, _y3);

                _x1 = value;
            }
        }

        public double Y1
        {
            get => _y1;

            set
            {
                CheckTriangle(_x1, value, _x2, _y2, _x3, _y3);

                _y1 = value;
            }
        }

        public double X2
        {
            get => _x2;

            set
            {
                CheckTriangle(_x1, _y1, value, _y2, _x3, _y3);

                _x2 = value;
            }
        }

        public double Y2
        {
            get => _y2;

            set
            {
                CheckTriangle(_x1, _y1, _x2, value, _x3, _y3);

                _y2 = value;
            }
        }

        public double X3
        {
            get => _x3;

            set
            {
                CheckTriangle(_x1, _y1, _x2, _y2, value, _y3);

                _x3 = value;
            }
        }

        public double Y3
        {
            get => _y3;

            set
            {
                CheckTriangle(_x1, _y1, _x2, _y2, _x3, value);

                _y3 = value;
            }
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            CheckTriangle(x1, y1, x2, y2, x3, y3);

            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
            _x3 = x3;
            _y3 = y3;
        }

        private static void CheckTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            const double epsilon = 1.0e-4;

            if (Math.Abs((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)) < epsilon)
            {
                throw new ArgumentException("Фигура не треугольник");
            }
        }

        public override string ToString()
        {
            return $"Треугольник с вершинами A({_x1:f1}; {_y1:f1}), B({_x2:f1}; {_y2:f1}), C({_x3:f1}; {_y3:f1})";
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return triangle._x1 == _x1 && triangle._y1 == _y1
                    && triangle._x2 == _x2 && triangle._y2 == _y2
                    && triangle._x3 == _x3 && triangle._y3 == _y3;
        }

        public override int GetHashCode()
        {
            const int prime = 37;

            var hash = prime + _x1.GetHashCode();

            hash = hash * prime + _y1.GetHashCode();
            hash = hash * prime + _x2.GetHashCode();
            hash = hash * prime + _y2.GetHashCode();
            hash = hash * prime + _x3.GetHashCode();
            hash = hash * prime + _y3.GetHashCode();

            return hash;
        }

        public double GetWidth()
        {
            var max = Math.Max(_x1, Math.Max(_x2, _x3));
            var min = Math.Min(_x1, Math.Min(_x2, _x3));

            return max - min;
        }

        public double GetHeight()
        {
            var max = Math.Max(_y1, Math.Max(_y2, _y3));
            var min = Math.Min(_y1, Math.Min(_y2, _y3));

            return max - min;
        }

        private static double GetEdgeLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public double GetEdgeAbLength()
        {
            return GetEdgeLength(_x1, _y1, _x2, _y2);
        }

        public double GetEdgeBcLength()
        {
            return GetEdgeLength(_x3, _y3, _x2, _y2);
        }

        public double GetEdgeAcLength()
        {
            return GetEdgeLength(_x1, _y1, _x3, _y3);
        }

        public double GetArea()
        {
            var edgeAbLength = GetEdgeAbLength();
            var edgeBcLength = GetEdgeBcLength();
            var edgeAcLength = GetEdgeAcLength();

            var semiPerimeter = (edgeAbLength + edgeBcLength + edgeAcLength) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - edgeAbLength) * (semiPerimeter - edgeBcLength) * (semiPerimeter - edgeAcLength));
        }

        public double GetPerimeter()
        {
            return GetEdgeAbLength() + GetEdgeBcLength() + GetEdgeAcLength();
        }
    }
}