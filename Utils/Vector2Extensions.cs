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

        public static void Random2D(this ref Vector2 v, int min, int max)
        {
            v = new Vector2(Random.Shared.Next(min, max), Random.Shared.Next(min, max));
            v = Vector2.Normalize(v);
        }

        public static void SetMag(this ref Vector2 v, float mag)
        {
            v = Vector2.Multiply(Vector2.Normalize(v), mag);
        }

        public static double Heading(this Vector2 v) => Math.Atan2(v.Y, v.X);
    }
}
