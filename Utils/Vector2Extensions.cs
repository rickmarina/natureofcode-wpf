using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace natureofcode_wpf.Utils
{
    public static class Vector2Extensions
    {

        public static void Limit(this ref Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                v = Vector2.Multiply(Vector2.Normalize(v), max);
            }

        }
    }
}
