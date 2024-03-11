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
public class ScenarioRandomWalker : ScenarioBase
{

    private Polyline _poly;
    private double currentX;
    private double currentY;

    public ScenarioRandomWalker(Canvas canvas) : base(canvas,"Random Walker")
    {
        currentX = _width / 2;
        currentY = _height / 2;

        _poly = new Polyline() {  StrokeThickness = 2, Stroke = GenerateRandomColorBrush() };
        _poly.Points.Add(new System.Windows.Point(currentX, currentY));
        _poly.Points.Add(new System.Windows.Point(currentX, currentY));

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(_poly);
    }

    public override void Update(long delta)
    {
        int dir = Random.Shared.Next(4);

        _ = dir switch
        {
            0 => currentX++,
            1 => currentX--,
            2 => currentY++,
            3 => currentY--,
            _ => 0
        };

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