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
using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;


public class ScenarioWindForcesBasic : ScenarioBase
{
    private Mover mover1; 
    private Mover mover2;
    private Vector2 gravity; 

    public ScenarioWindForcesBasic(Canvas canvas) : base(canvas,"Wind & gravity forces basic")
    {
        var shape1 = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        mover1 = new Mover(_width/2, _height/2, 10, shape1);

        var shape2 = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };
        mover2 = new Mover(_width/3, _height/2, 2, shape2);
        gravity = new Vector2(0, 0.1f); 

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(mover1.shape);
        this._canvas.Children.Add(mover2.shape);
    }

    public override void Update(long delta)
    {

        //Gravity affects independient of the mass
        mover1.ApplyForce(Vector2.Multiply(gravity, mover1.GetMass));
        mover2.ApplyForce(Vector2.Multiply(gravity, mover2.GetMass));

        if (mouseLeftPressed)
        {
            mover1.ApplyForce(new Vector2(0.05f, 0));
            mover2.ApplyForce(new Vector2(0.05f, 0));
        }


        mover1.Update();
        mover1.Display();
        mover1.CheckEdges(boundary);

        mover2.Update();
        mover2.Display();
        mover2.CheckEdges(boundary);

    }



}