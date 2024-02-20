using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;


public class ScenarioForcesAttractionManyMoversMutual : ScenarioBase, IScenario
{
    private const int TOTAL_MOVERS = 500;
    private List<Mover> movers;

    public ScenarioForcesAttractionManyMoversMutual(Canvas canvas) : base(canvas,"Attraction with Many Movers Mutual Attraction")
    {

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
            mover.ApplyForce(new Vector2(0, 0));
            movers.Add(mover);
        }

    }

    public void Draw()
    {
        this._canvas.Children.Clear();

        foreach (var m in movers) 
            this._canvas.Children.Add(m.shape);

    }

    public void Update(long delta)
    {

        for (int i=0;i< TOTAL_MOVERS;i++)
        {
            for (int j=0; j< TOTAL_MOVERS; j++)
            {
                if (i != j)
                {
                    Vector2 force = movers[j].Attract(movers[i]);
                    movers[i].ApplyForce(force);
                }
            }

            movers[i].Update();
            movers[i].Display();

        }


    }



}