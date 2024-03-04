using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace natureofcode_wpf.Models
{
    public class Circle : Shape
    {
        public double Radio { get; set; }

        protected override Geometry DefiningGeometry
        {
            get
            {
                EllipseGeometry ellipseGeometry = new EllipseGeometry(new Point(0, 0), Radio, Radio);
                LineGeometry radioLine = new LineGeometry(new Point(0, 0), new Point(Radio, 0));
                GeometryGroup group = new GeometryGroup();
                group.Children.Add(ellipseGeometry);
                group.Children.Add(radioLine);

                return group;
            }
        }
    }
}
