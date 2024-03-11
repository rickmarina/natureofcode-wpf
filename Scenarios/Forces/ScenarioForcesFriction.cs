using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;


public class ScenarioForcesFriction : ScenarioBase
{
    private Mover mover1; 
    private Vector2 gravity;
    private Vector2 friction; 

    public ScenarioForcesFriction(Canvas canvas) : base(canvas,"Friction")
    {
        var shape1 = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        mover1 = new Mover(_width/2, _height/2, 6, shape1);
        gravity = new Vector2(0, 0.1f);

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(mover1.shape);
    }

    public override void Update(long delta)
    {
        //Gravity affects independient of the mass
        mover1.ApplyForce(Vector2.Multiply(gravity, mover1.GetMass));

        if (mouseLeftPressed)
        {
            mover1.ApplyForce(new Vector2(0.05f, 0));
        }

        if (mover1.ContactEdge(boundary))
        {
            float frictionCoef = 0.1f;
            friction = Vector2.Multiply(mover1.Velocity, -1);
            friction.SetMag(frictionCoef);

            mover1.ApplyForce(friction); 
        }

        mover1.BoundeEdges(boundary);
        mover1.Update();
        mover1.Display();
    }



}