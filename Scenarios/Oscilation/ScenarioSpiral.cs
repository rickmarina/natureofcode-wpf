using natureofcode_wpf.Utils;
using System;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace natureofcode_wpf.Scenarios.Oscilation
{
    internal class ScenarioSpiral : ScenarioBase
    {
        float r;
        double theta;
        Polyline pline = new Polyline()
        {
            Stroke = Brushes.Black, 
            StrokeThickness = 4
        };

        public ScenarioSpiral(Canvas canvas) : base(canvas, "Spiral")
        {
            pline.Points.Add(new Point(0, 0));
            r = 1;
            theta = 0; 

        }
        public override void Setup()
        {
            _canvas.RenderTransform = Translate(_width / 2, _height / 2); // Just 1 translation of 0,0 to the center is enough for this scene

            this._canvas.Children.Clear();
            this._canvas.Children.Add(pline);

        }

        public override void Update(long delta)
        {
            var v = Vector2.Multiply(Degrees.FromAngle(theta), r);
            
            pline.Points.Add(new Point(v.X, v.Y));

            theta = theta + 0.02;
            r += 0.05f;

        }
    }
}
