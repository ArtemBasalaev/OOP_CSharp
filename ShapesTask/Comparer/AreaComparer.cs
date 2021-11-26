using System;
using System.Collections.Generic;
using ShapesTask.Shapes;

namespace ShapesTask.Comparer
{
    public class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (ReferenceEquals(shape1, null) || ReferenceEquals(shape2, null))
            {
                throw new NullReferenceException("Передана пустая ссылка");
            }

            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}