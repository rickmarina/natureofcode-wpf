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
public class ScenarioVectorsMultiplying : ScenarioBase
{

    Vector2 center;

    public ScenarioVectorsMultiplying(Canvas canvas) : base(canvas,"Multiplying vectors")
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

        mouse = Vector2.Multiply(mouse, 0.5f);

        Line lMouseMultiply = new Line()
        {
            X1 = 0,
            Y1 = 0,
            X2 = mouse.X,
            Y2 = mouse.Y,
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            RenderTransform = Translate(_width / 2, _height / 2) // origin as center of canvas
        };
        this._canvas.Children.Add(lMouseMultiply);



    }



}