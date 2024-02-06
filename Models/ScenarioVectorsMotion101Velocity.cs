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


public class ScenarioVectorsMotion101Velocity : ScenarioBase, IScenario
{

    Vector2 position;
    Vector2 velocity;

    Ellipse ball; 

    public ScenarioVectorsMotion101Velocity(Canvas canvas) : base(canvas,"Motion 101 Velocity")
    {
        position = new Vector2(Random.Shared.Next(_width), Random.Shared.Next(_height));
        velocity = new Vector2(Random.Shared.Next(-2, 2), Random.Shared.Next(-2, 2));

        ball = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

    }

    public void Draw()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(ball);
    }

    public void Update(long delta)
    {
        
        position = Vector2.Add(position, velocity);

        if (position.X > _width)
            position.X = 0;
        else if (position.X < 0)
            position.X = _width;

        if (position.Y > _height) position.Y = 0;
        else if (position.Y < 0) position.Y = _height;


        Canvas.SetLeft(ball, position.X);
        Canvas.SetTop(ball, position.Y);


    }



}