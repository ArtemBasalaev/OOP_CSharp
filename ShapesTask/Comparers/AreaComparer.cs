using System.Collections.Generic;
using ShapesTask.Shapes;

namespace ShapesTask.Comparers
{
    public class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (ReferenceEquals(shape1, null) && ReferenceEquals(shape2, null))
            {
                return 0;
            }

            if (ReferenceEquals(shape1, null))
            {
                return -1;
            }

            if (ReferenceEquals(shape2, null))
            {
                return 1;
            }

            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}