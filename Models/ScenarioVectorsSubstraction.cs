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
public class ScenarioVectorsSubstraction : ScenarioBase, IScenario
{

    Vector2 mouse;
    Vector2 center;

    public ScenarioVectorsSubstraction(Canvas canvas) : base(canvas,"Substraction vectors")
    {
        center = new Vector2(_width/2, _height/2);
    }

    public void Draw()
    {
        this._canvas.Children.Clear();
    }

    public void Update(long delta)
    {
        this._canvas.Children.Clear();

        mouse = new Vector2((float)Mouse.GetPosition(_canvas).X, (float)Mouse.GetPosition(_canvas).Y);

        Line lMouse = new Line()
        {
            X1 = 0,
            Y1 = 0,
            X2 = mouse.X,
            Y2 = mouse.Y,
            StrokeThickness = 2, 
            Stroke = Brushes.LightGray
        };

        Line lCenter = new Line()
        {
            X1 = 0,
            Y1 = 0,
            X2 = center.X,
            Y2 = center.Y,
            StrokeThickness = 2,
            Stroke = Brushes.LightGray
        };

        this._canvas.Children.Add(lMouse);
        this._canvas.Children.Add(lCenter);

        var sub = Vector2.Subtract(mouse, center);


        Line lSub = new Line()
        {
            X1 = center.X,
            Y1 = center.Y,
            X2 = sub.X + center.X,
            Y2 = sub.Y + center.Y,
            StrokeThickness = 4,
            Stroke = Brushes.Black
        };

        this._canvas.Children.Add(lSub);

    }



}