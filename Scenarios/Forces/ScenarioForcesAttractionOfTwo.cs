using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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


public class ScenarioForcesAttractionOfTwo : ScenarioBase, IScenario
{
    private Mover mover1;
    private Mover mover2;

    public ScenarioForcesAttractionOfTwo(Canvas canvas) : base(canvas,"Attraction of Two")
    {

        var shapeMover1 = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };
        var shapeMover2 = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        mover1 = new Mover(_width/2, 70, 2, shapeMover1);
        mover2 = new Mover(_width / 2, 270, 2, shapeMover2);

        mover1.ApplyForce(new Vector2(1, 0));
        mover2.ApplyForce(new Vector2(-1, 0));
    }

    public void Draw()
    {
        this._canvas.Children.Clear();

        this._canvas.Children.Add(mover1.shape);
        this._canvas.Children.Add(mover2.shape);

    }

    public void Update(long delta)
    {

        Vector2 force2 = mover1.Attract(mover2);
        Vector2 force1 = mover2.Attract(mover1);

        mover1.ApplyForce(force1);
        mover2.ApplyForce(force2);

        mover1.Update();
        mover2.Update();
        mover1.Display();
        mover2.Display();


    }



}