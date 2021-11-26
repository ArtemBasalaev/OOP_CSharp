using System;
using ShapesTask.Comparer;
using ShapesTask.Shapes;

namespace ShapesTask
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                IShape[] shapes =
                {
                    new Square(1.0),
                    new Circle(1.3),
                    new Rectangle(1.3, 1.5),
                    new Triangle(0, 0, 0, 5, 5, 0),
                    new Circle(1.1),
                    new Square(1.2)
                };
                Console.WriteLine("В массиве хранятся следующие фигуры:");
                foreach (var shape in shapes)
                {
                    Console.WriteLine($"- {shape}");
                }

                Array.Sort(shapes, new AreaComparer());

                var shape1 = shapes[^1];
                var shape1Area = shapes[^1].GetArea();
                Console.WriteLine($"Фигура с наибольшей площадью: {shape1}, S = {shape1Area:f2}");

                Array.Sort(shapes, new PerimeterComparer());

                var shape2 = shapes[^2];
                var shape2Perimeter = shapes[^2].GetPerimeter();
                Console.WriteLine($"Фигура со вторым по величине периметром: {shape2}, P = {shape2Perimeter:f2}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ошибка! {e}");
            }
        }
    }
}