﻿using System;
using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.Comparator
{
    public class PerimeterComparator : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (ReferenceEquals(shape1, null) || ReferenceEquals(shape2, null))
            {
                throw new NullReferenceException("Передана пустая ссылка");
            }

            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}