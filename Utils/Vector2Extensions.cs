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

        public static void Random2D(this ref Vector2 v)
        {
            v = new Vector2(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100));
            v = Vector2.Normalize(v);
        }
    }
}
