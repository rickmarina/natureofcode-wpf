using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;


public class ScenarioOscilationAngularMotionTest : ScenarioBase
{
    private Mover mover1; 
    private Mover mover2;
    private double angle;

    public ScenarioOscilationAngularMotionTest(Canvas canvas) : base(canvas, "Angular motion Test")
    {
        Circle r1 = new Circle()
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Fill = Brushes.LightBlue,
            Width = 100,
            Height = 100,
            Radio = 40
        };

        Rectangle r2 = new Rectangle()
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            Fill = Brushes.LightBlue,
            Width = 100,
            Height = 100
        };

        mover1 = new Mover(_width / 2, _height / 2, 400, r1);
        mover2 = new Mover(_width / 2, _height / 2, 4, r2);
        Canvas.SetLeft(mover2.shape, Random.Shared.Next(_width / 2));
        Canvas.SetTop(mover2.shape, Random.Shared.Next(_height / 2));

    }

    public override void Setup()
    {
        this._canvas.Children.Clear(); 
        this._canvas.Children.Add(mover1.shape);
        this._canvas.Children.Add(mover2.shape);

        mover1.Display();

    }

    public override void Update(long delta)
    {

        mover1.Rotate(Degrees.RadiansToDegrees(angle));


        angle += 0.01;
     /*
      TransformGroup transforms = new TransformGroup();
        transforms.Children.Add(new RotateTransform(Degrees.RadiansToDegrees(angle)));
        transforms.Children.Add(new TranslateTransform(_width / 2, _height / 2));
        _canvas.RenderTransform = transforms;

        angleVelocity += angleAcceleration;
        angle += angleVelocity;
     */

    }



}