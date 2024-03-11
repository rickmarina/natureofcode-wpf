using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using NatureOfCode.Models;


public class ScenarioVectorsMagnitude : ScenarioBase
{

    Vector2 center;

    public ScenarioVectorsMagnitude(Canvas canvas) : base(canvas,"Vector Magnitude")
    {
        center = new Vector2(_width/2, _height/2);
    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
    }

    public override void Update(long delta)
    {
        this._canvas.Children.Clear();

        Vector2 mouse = new Vector2((float)Mouse.GetPosition(_canvas).X, (float)Mouse.GetPosition(_canvas).Y);

        mouse = Vector2.Subtract(mouse, center); //substract in order to have the vector from center of mouse location
        Line lMouse = new Line()
        {
            X1 = 0,
            Y1 = 0,
            X2 = mouse.X,
            Y2 = mouse.Y,
            StrokeThickness = 3, 
            Stroke = Brushes.LightGray,
            RenderTransform = Translate(_width/2, _height/2) // origin as center of canvas
        };
        this._canvas.Children.Add(lMouse);

        var r = new Rectangle()
        {
            Width = mouse.Length(),
            Height = 50,
            Fill = Brushes.LightGray,
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };
        Canvas.SetLeft(r, 0);
        Canvas.SetTop(r, 0);

        _canvas.Children.Add(r);

    }



}