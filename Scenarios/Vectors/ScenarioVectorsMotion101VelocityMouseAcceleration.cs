using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using NatureOfCode.Models;
using natureofcode_wpf.Utils;


public class ScenarioVectorsMotion101VelocityMouseAcceleration : ScenarioBase, IScenario
{

    private Vector2 position;
    private Vector2 velocity;
    private Vector2 acceleration;

    private int topSpeed = 6;

    Ellipse ball;

    public ScenarioVectorsMotion101VelocityMouseAcceleration(Canvas canvas) : base(canvas,"Motion 101 Velocity and mouse acceleration")
    {
        position = new Vector2(Random.Shared.Next(_width), Random.Shared.Next(_height));
        velocity = new Vector2(Random.Shared.Next(-2, 2), Random.Shared.Next(-2, 2));
        acceleration.Random2D();

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
        Vector2 mouse = new Vector2((float)Mouse.GetPosition(_canvas).X, (float)Mouse.GetPosition(_canvas).Y);

        Vector2 dir = Vector2.Subtract(mouse, position);
        dir.SetMag(0.2f);
        //dir = Vector2.Normalize(dir);
        //dir = Vector2.Multiply(dir, 0.2f);

        acceleration = dir;

        velocity = Vector2.Add(velocity, acceleration);
        velocity.Limit(topSpeed);
        position = Vector2.Add(position, velocity);



        if (position.X > _width)
            position.X = 0;
        else if (position.X < 0)
            position.X = _width;

        if (position.Y > _height) position.Y = 0;
        else if (position.Y < 0) position.Y = _height;


        Canvas.SetLeft(ball, position.X-20);
        Canvas.SetTop(ball, position.Y-20);


    }



}