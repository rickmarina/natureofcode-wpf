using System.Collections.Generic;
using System.Windows.Shapes;
using NatureOfCode.Models;
using System.Windows.Controls;
using System;
using System.Diagnostics;
using Accessibility;

public class ScenarioGraphPerlinNoise : ScenarioBase, IScenario
{

    private Polyline _poly;
    private double time; 

    public ScenarioGraphPerlinNoise(Canvas canvas) : base(canvas, "Perlin Noise Values Over Time")
    {
        time = 1; 
        _poly = new Polyline() {  StrokeThickness = 3, Stroke = Brushes.Random() };
    }

    public void Draw()
    {
        _canvas.Children.Add(_poly);
    }

    public void Update(long delta)
    {
        _poly.Points.Clear();

        double xoff = time;
        for (int x = 0; x < _width; x++)
        {
            double perlinValue = PerlinNoise.Noise01(xoff, xoff, xoff);
            double y = (perlinValue * _height);
            _poly.Points.Add(new System.Windows.Point(x, y));

            xoff += 0.02;
        }

        time += 0.02;

    }
}