using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace natureofcode_wpf.Utils
{
    public class Degrees
    {
        public static double DegreesToRadians(double d) => d * Math.PI / 180;
        public static double RadiansToDegrees(double r) => r * 180 / Math.PI;
    }
}
