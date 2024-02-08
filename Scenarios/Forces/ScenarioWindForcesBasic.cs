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


public class ScenarioWindForcesBasic : ScenarioBase, IScenario
{
    private Mover mover; 
    private Vector2 gravity; 

    public ScenarioWindForcesBasic(Canvas canvas) : base(canvas,"Wind & gravity forces basic")
    {
        var shape = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        mover = new Mover(_width/2, _height/2, 1, shape);
        gravity = new Vector2(0, 0.1f); 

    }

    public void Draw()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(mover.shape);
    }

    public void Update(long delta)
    {
        mover.ApplyForce(gravity);

        if (mouseLeftPressed)
            mover.ApplyForce(new Vector2(0.05f, 0));


        mover.Update();
        mover.Display();
        mover.CheckEdges(boundary);


    }



}