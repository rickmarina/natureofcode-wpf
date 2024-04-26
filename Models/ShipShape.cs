using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace natureofcode_wpf.Models
{
    public class ShipShape : Shape
    {

        protected override Geometry DefiningGeometry
        {
            get
            {

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(Width/2, 0); // Punto inicial

                // Crear los segmentos del triángulo
                LineSegment segment1 = new LineSegment(new Point(0, Width), true);
                LineSegment segment2 = new LineSegment(new Point(Width, Width), true);

                // Agregar los segmentos al PathFigure
                pathFigure.Segments.Add(segment1);
                pathFigure.Segments.Add(segment2);

                // Cerrar el PathFigure
                pathFigure.IsClosed = true;


                PathGeometry path = new PathGeometry();
                path.Figures.Add(pathFigure);

                RectangleGeometry motorL = new RectangleGeometry() { Rect = new Rect(0, Width, Width / 5, Width / 5) };
                RectangleGeometry motorR = new RectangleGeometry() { Rect = new Rect(Width- (Width / 5), Width, Width / 5, Width / 5) };

                GeometryGroup group = new GeometryGroup();
                group.Children.Add(path);
                group.Children.Add(motorL);
                group.Children.Add(motorR);
                    

                return group;
            }
        }
    }
}
