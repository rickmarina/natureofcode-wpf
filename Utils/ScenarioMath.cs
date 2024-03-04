using System;

namespace natureofcode_wpf.Utils
{
    public class ScenarioMath
    {
        public static double Constrain(double x, double min, double max)
        {
            return Math.Min(Math.Max(x, min), max); 
        }
    }
}
