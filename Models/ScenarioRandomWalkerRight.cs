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
public class ScenarioRandomWalkerRight : IScenario
{

    private Polyline _poly;
    private readonly Canvas _canvas;
    private readonly int _width;
    private readonly int _height;

    private double currentX;
    private double currentY;
    public string GetTitle() => "Random Walker Tends to Move to the right";

    public ScenarioRandomWalkerRight(Canvas canvas)
    {
        _canvas = canvas;
        this._width = Convert.ToInt32(canvas.ActualWidth);
        this._height = Convert.ToInt32(canvas.ActualHeight);

        currentX = _width / 2;
        currentY = _height / 2;

        _poly = new Polyline() {  StrokeThickness = 2, Stroke = Brushes.Random() };
        _poly.Points.Add(new System.Windows.Point(currentX, currentY));

    }

    public void Draw()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(_poly);
    }

    public void Update(long delta)
    {
        double dir = Random.Shared.NextDouble();

        _ = dir switch
        {
            < 0.4 => currentX++,
            < 0.6 => currentX--,
            < 0.8 => currentY++,
            < 1 => currentY--
        };

        _poly.Points.Add(new System.Windows.Point(currentX, currentY));
    }


 
}