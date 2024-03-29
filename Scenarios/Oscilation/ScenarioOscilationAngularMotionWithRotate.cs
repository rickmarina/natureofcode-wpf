using System;
using System.Diagnostics;
using System.Numerics;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;


public class ScenarioOscilationAngularMotionWithRotate : ScenarioBase
{
    private double angle = 0;
    private double angleVelocity = 0;
    private double angleAcceleration = 0.0001;
    private Ellipse circle1;
    private Ellipse circle2;
    private Line line1;

    public ScenarioOscilationAngularMotionWithRotate(Canvas canvas) : base(canvas, "Angular motion using rotate")
    {
        line1 = new Line()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            X1 = -150,
            Y1 = 0, 
            X2 = 150, 
            Y2 = 0
        };

        circle1 = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        circle2 = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };


    }

    public override void Setup()
    {
        this._canvas.Children.Add(line1);
        this._canvas.Children.Add(circle1);
        this._canvas.Children.Add(circle2);

        Canvas.SetLeft(circle1, -170);
        Canvas.SetTop(circle1, -20);
        Canvas.SetLeft(circle2, 130);
        Canvas.SetTop(circle2, -20);
    }

    public override void Update(long delta)
    {
        TransformGroup transforms = new TransformGroup();
        transforms.Children.Add(new RotateTransform(Degrees.RadiansToDegrees(angle)));
        transforms.Children.Add(new TranslateTransform(_width / 2, _height / 2));
        _canvas.RenderTransform = transforms;

        angleVelocity += angleAcceleration;
        angle += angleVelocity;

    }

}