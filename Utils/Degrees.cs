using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace natureofcode_wpf.Utils
{
    public class Degrees
    {
        public static double DegreesToRadians(double d) => d * Math.PI / 180;
        public static double RadiansToDegrees(double r) => r * 180 / Math.PI;

        /// <summary>
        /// From radians angle to unit vector in cartesian
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Vector2 FromAngle(double angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
    }
}
