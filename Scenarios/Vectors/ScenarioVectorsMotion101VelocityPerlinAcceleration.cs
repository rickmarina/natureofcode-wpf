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


public class ScenarioVectorsMotion101VelocityPerlinAcceleration : ScenarioBase
{

    private Vector2 position;
    private Vector2 velocity;
    private Vector2 acceleration;
    private int topSpeed = 5;
    private double timeX = 0;
    private double timeY = 1000;

    Ellipse ball;
    Label labelVelocity;

    public ScenarioVectorsMotion101VelocityPerlinAcceleration(Canvas canvas) : base(canvas,"Motion 101 Velocity and Perlin acceleration")
    {
        position = new Vector2(Random.Shared.Next(_width), Random.Shared.Next(_height));
        velocity = new Vector2(Random.Shared.Next(-2, 2), Random.Shared.Next(-2, 2));
        acceleration.Random2D(-100, 100);

        ball = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        labelVelocity = new Label()
        {
            Content = "vel:",
        };

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(ball);
        this._canvas.Children.Add(labelVelocity);
    }

    public override void Update(long delta)
    {

        double x = PerlinNoise.Noise(timeX, timeX, timeX);
        double y = PerlinNoise.Noise(timeY, timeY, timeY);

        acceleration = new Vector2((float)x, (float)y);

        velocity = Vector2.Add(velocity, acceleration);
        velocity.Limit(topSpeed);

        position = Vector2.Add(position, velocity);

        labelVelocity.Content = $"vel: {velocity.Length().ToString("#.##")}";


        if (position.X > _width)
            position.X = 0;
        else if (position.X < 0)
            position.X = _width;

        if (position.Y > _height) position.Y = 0;
        else if (position.Y < 0) position.Y = _height;


        Canvas.SetLeft(ball, position.X);
        Canvas.SetTop(ball, position.Y);

        Canvas.SetLeft(labelVelocity, position.X + 35);
        Canvas.SetTop(labelVelocity, position.Y + 15);

        timeX += 0.005;
        timeY += 0.005;
    }



}