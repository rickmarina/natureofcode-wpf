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
public class ScenarioRandomWalker8Directions : IScenario
{

    private Polyline _poly;
    private readonly Canvas _canvas;
    private readonly int _width;
    private readonly int _height;

    private double currentX;
    private double currentY;

    public ScenarioRandomWalker8Directions(Canvas canvas)
    {
        _canvas = canvas;
        this._width = Convert.ToInt32(canvas.ActualWidth);
        this._height = Convert.ToInt32(canvas.ActualHeight);

        currentX = _width / 2;
        currentY = _height / 2;

        _poly = new Polyline() {  StrokeThickness = 2, Stroke = GenerateRandomColorBrush() };
        _poly.Points.Add(new System.Windows.Point(currentX, currentY));
        _poly.Points.Add(new System.Windows.Point(currentX, currentY));

    }

    public void Draw()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(_poly);
    }

    public void Update(long delta)
    {
        int xstep = Random.Shared.Next(-1,2);
        int ystep = Random.Shared.Next(-1,2);

        currentX += xstep;
        currentY += ystep; 

        _poly.Points.Add(new System.Windows.Point(currentX, currentY));
    }


    private SolidColorBrush GenerateRandomColorBrush()
    {
        Random rnd = new Random();
        byte[] rgb = new byte[3];
        rnd.NextBytes(rgb);

        Color randomColor = Color.FromRgb(rgb[0], rgb[1], rgb[2]);
        SolidColorBrush randomColorBrush = new SolidColorBrush(randomColor);

        return randomColorBrush;
    }

    

 
}