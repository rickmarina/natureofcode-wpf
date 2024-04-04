using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;


public class ScenarioForcesWithAngularMotion : ScenarioBase
{
    private List<Mover> movers;
    private Attractor attractor;
    private Ellipse e;

    public ScenarioForcesWithAngularMotion(Canvas canvas) : base(canvas, "Forces with angular motion")
    {
        e = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = new SolidColorBrush(Colors.Red),
            Width = 150,
            Height = 100,
            Fill = new SolidColorBrush(Colors.Red)
        };

        attractor = new Attractor(_width / 2, _height / 2, 4, e);


        movers = new();
        for (int i=0;i<20;i++)
        {
            int radio = Random.Shared.Next(10, 20);
            RadioCircle c = new RadioCircle()
            {
                StrokeThickness = 2,
                Stroke = Brushes.Black,
                Fill = Brushes.LightGray,
                Width= radio*2,
                Height= radio*2,
                Radio = radio
            };

            var mov = new Mover(Random.Shared.Next(_width), Random.Shared.Next(_height), 4, c);
            mov.ApplyForce(new Vector2(Random.Shared.Next(-1, 1), Random.Shared.Next(-1, 1)));

            movers.Add(mov);
        }

        

    }

    public override void Setup() 
    {
        this._canvas.Children.Clear();

        foreach (var m in movers) { 
            this._canvas.Children.Add(m.shape);
        }

        this._canvas.Children.Add(attractor.shape);
        attractor.Display();

    }

    public override void Update(long delta)
    {
        foreach (var m in movers)
        {

            var force = attractor.Attract(m);
            m.ApplyForce(force);
            m.ApplyAngularAcceleration(m.Acceleration.X / 10.0f);

            m.Update();
            m.Display();
        }
    }



}