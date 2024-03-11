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
public class ScenarioRandomWalkerRight : ScenarioBase
{

    private Polyline _poly;
    private double currentX;
    private double currentY;

    public ScenarioRandomWalkerRight(Canvas canvas) : base(canvas, "Random Walker Tends to Move to the right")
    {
        currentX = _width / 2;
        currentY = _height / 2;

        _poly = new Polyline() {  StrokeThickness = 2, Stroke = Brushes.Random() };
        _poly.Points.Add(new System.Windows.Point(currentX, currentY));

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(_poly);
    }

    public override void Update(long delta)
    {
        double dir = Random.Shared.NextDouble();

        _ = dir switch
        {
            < 0.4 => currentX++,
            < 0.6 => currentX--,
            < 0.8 => currentY++,
            < 1 => currentY--,
            _ => 0
        };

        _poly.Points.Add(new System.Windows.Point(currentX, currentY));
    }


 
}