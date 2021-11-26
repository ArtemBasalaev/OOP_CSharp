using System;

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

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            if (!IsTriangle(x1, y1, x2, y2, x3, y3))
            {
                throw new ArgumentException("Фигура не треугольник ");
            }

            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
            _x3 = x3;
            _y3 = y3;
        }

        public double X1
        {
            get => _x1;

            set
            {
                if (!IsTriangle(value, _y1, _x2, _y2, _x3, _y3))
                {
                    throw new ArgumentException("Фигура не треугольник");
                }

                _x1 = value;
            }
        }

        public double Y1
        {
            get => _y1;

            set
            {
                if (!IsTriangle(_x1, value, _x2, _y2, _x3, _y3))
                {
                    throw new ArgumentException("Фигура не треугольник");
                }

                _y1 = value;
            }
        }

        public double X2
        {
            get => _x2;

            set
            {
                if (!IsTriangle(_x1, _y1, value, _y2, _x3, _y3))
                {
                    throw new ArgumentException("Фигура не треугольник");
                }

                _x2 = value;
            }
        }

        public double Y2
        {
            get => _y2;

            set
            {
                if (!IsTriangle(_x1, _y1, _x2, value, _x3, _y3))
                {
                    throw new ArgumentException("Фигура не треугольник");
                }

                _y2 = value;
            }
        }

        public double X3
        {
            get => _x3;

            set
            {
                if (!IsTriangle(_x1, _y1, _x2, _y2, value, _y3))
                {
                    throw new ArgumentException("Фигура не треугольник");
                }

                _x3 = value;
            }
        }

        public double Y3
        {
            get => _y3;

            set
            {
                if (!IsTriangle(_x1, _y1, _x2, _y2, _x3, value))
                {
                    throw new ArgumentException("Фигура не треугольник");
                }

                _y3 = value;
            }
        }

        private static bool IsTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Math.Abs((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)) > 1.0e-4;
        }

        public override string ToString()
        {
            return $"Треугольник с вершинами A({_x1:f1}; {_y1:f1}), B({_x2:f1}; {_y2:f1}), C({_x3:f1}; {_y3:f1})";
        }

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

            return (Math.Abs(triangle._x1 - _x1) < 1.0e-4) && (Math.Abs(triangle._y1 - _y1) < 1.0e-4)
                    && (Math.Abs(triangle._x2 - _x2) < 1.0e-4) && (Math.Abs(triangle._y2 - _y2) < 1.0e-4)
                    && (Math.Abs(triangle._x3 - _x3) < 1.0e-4) && (Math.Abs(triangle._y3 - _y3) < 1.0e-4);
        }

        public override int GetHashCode()
        {
            int prime = 37;

            int hash = prime + _x1.GetHashCode();

            hash = hash * prime + _y1.GetHashCode();
            hash = hash * prime + _x2.GetHashCode();
            hash = hash * prime + _y2.GetHashCode();
            hash = hash * prime + _x3.GetHashCode();
            hash = hash * prime + _y3.GetHashCode();

            return hash;
        }

        public double GetWidth()
        {
            double max = Math.Max(_x1, Math.Max(_x2, _x3));
            double min = Math.Min(_x1, Math.Min(_x2, _x3));

            return max - min;
        }

        public double GetHeight()
        {
            double max = Math.Max(_y1, Math.Max(_y2, _y3));
            double min = Math.Min(_y1, Math.Min(_y2, _y3));

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
            double edgeAbLength = GetEdgeAbLength();
            double edgeBcLength = GetEdgeBcLength();
            double edgeAcLength = GetEdgeAcLength();

            double semiPerimeter = (edgeAbLength + edgeBcLength + edgeAcLength) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - edgeAbLength) * (semiPerimeter - edgeBcLength) * (semiPerimeter - edgeAcLength));
        }

        public double GetPerimeter()
        {
            return GetEdgeAbLength() + GetEdgeBcLength() + GetEdgeAcLength();
        }
    }
}