using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NatureOfCode.Models;
public class ScenarioPerlinNoiseWalker : ScenarioBase
{
    private double timeX;
    private double timeY;

    public ScenarioPerlinNoiseWalker(Canvas canvas) : base(canvas,"Perlin Noise Walker")
    {
        timeX = 0;
        timeY = 1000;
    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
    }

    public override void Update(long delta)
    {
        double x = PerlinNoise.Noise01(timeX, timeX, timeX);
        double y = PerlinNoise.Noise01(timeY, timeY, timeY);

        var e = new Ellipse()
        {
            Width = 30,
            Height = 30,
            StrokeThickness = 2,
            Stroke = Brushes.Random(),
            Fill = Brushes.Random()
        };

        Canvas.SetLeft(e, x*_width);
        Canvas.SetTop(e, y*_height);
        this._canvas.Children.Add(e);

        timeX += 0.005;
        timeY += 0.005;

    }


 
}