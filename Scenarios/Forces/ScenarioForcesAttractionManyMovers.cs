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


public class ScenarioForcesAttractionManyMovers : ScenarioBase
{
    private const int TOTAL_MOVERS = 500;
    private List<Mover> movers;
    private Attractor attractor;

    public ScenarioForcesAttractionManyMovers(Canvas canvas) : base(canvas,"Attraction with Many Movers")
    {
        var shapeAttractor = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };
        attractor = new Attractor(_width / 2, _height / 2, 5, shapeAttractor);


        movers = new();
        for (int i = 0; i < TOTAL_MOVERS; i++)
        {
            var shapeMover = new Ellipse()
            {
                StrokeThickness = 2,
                Stroke = Brushes.Black,
                Fill = Brushes.LightGray,
                Width = 40,
                Height = 40
            };

            

            var mover = new Mover(Random.Shared.Next(_width), Random.Shared.Next(_height), (float)Random.Shared.NextDouble() * 4 + 1, shapeMover);
            mover.ApplyForce(new Vector2(1.5f, 0));
            movers.Add(mover);
        }

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();

        foreach (var m in movers) 
            this._canvas.Children.Add(m.shape);

        this._canvas.Children.Add(attractor.shape);
    }

    public override void Update(long delta)
    {
        attractor.Display();

        if (mouseMove)
        {
            attractor.HandleHover(mouseX, mouseY);
        }
        if (mouseDragg)
        {
            attractor.HandleDragged(mouseX, mouseY);
        }
        if (mouseLeftPressed)
        {
            attractor.HandlePress(mouseX, mouseY);
        }
        if (mouseLeftReleased)
        {
            attractor.StopDragging();
        }

        foreach (var m in movers) { 
            Vector2 force = attractor.Attract(m);
            m.ApplyForce(force); 

            m.Update();
            m.Display();
        }


    }



}