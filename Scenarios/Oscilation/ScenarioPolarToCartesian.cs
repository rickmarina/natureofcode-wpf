using natureofcode_wpf.Utils;
using System;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace natureofcode_wpf.Scenarios.Oscilation
{
    internal class ScenarioPolarToCartesian : ScenarioBase
    {

        Line line;
        Ellipse circle; 
        float r;
        double theta; 

        public ScenarioPolarToCartesian(Canvas canvas) : base(canvas, "Polar To Cartesian")
        {

            r = _height * 0.35f;
            theta = 0; 

            line = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 0,
                Y1 = 0
            };

            circle = new Ellipse()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.LightBlue,
                Width = 30,
                Height = 30
            };



        }
        public override void Setup()
        {
            _canvas.RenderTransform = Translate(_width / 2, _height / 2); // Just 1 translation of 0,0 to the center is enough for this scene

            this._canvas.Children.Clear();
            this._canvas.Children.Add(line);
            this._canvas.Children.Add(circle);

        }

        public override void Update(long delta)
        {
            var v = Vector2.Multiply(Degrees.FromAngle(theta), r);
            
            line.X2 = v.X; line.Y2 = v.Y;

            Canvas.SetTop(circle, v.Y - (circle.Height / 2));
            Canvas.SetLeft(circle,v.X - (circle.Width / 2));

            theta = (theta + 0.02) % (Math.PI*2);

        }
    }
}
