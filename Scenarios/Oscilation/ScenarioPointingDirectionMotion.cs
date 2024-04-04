using System;
using System.Diagnostics;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;


public class ScenarioPointingDirectionMotion : ScenarioBase
{
    private Mover mover;
    private double angle = 0;

    public ScenarioPointingDirectionMotion(Canvas canvas) : base(canvas, "Pointing in the Direction of Motion")
    {
        var shapeQuad = new System.Windows.Shapes.Rectangle()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 20,
            RenderTransformOrigin = new Point(0.5, 0.5)
        };

        mover = new Mover(_width/2, _height/2, 3, shapeQuad);
        mover.topVelocity = 3;
    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(mover.shape);

    }

    public override void Update(long delta)
    {

        Vector2 mouse = new Vector2((float)mouseX, (float)mouseY);
        Vector2 dir = Vector2.Normalize(mouse - mover.Position);
        dir.SetMag(0.5f);

        mover.ApplyForce(dir);

        mover.Update();
        mover.CheckEdges(boundary);
        mover.Display();

        //double angle = Math.Atan2(this.mover.Velocity.Y, this.mover.Velocity.X);
        double angle = this.mover.Velocity.Heading();

        mover.Rotate(angle);

    }



}