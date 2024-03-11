using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Xml;
using NatureOfCode.Models;
using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;


public class ScenarioForcesFluidResistance : ScenarioBase
{
    private List<Mover> movers; 
    private Vector2 gravity;
    private Fluid liquid; 

    public ScenarioForcesFluidResistance(Canvas canvas) : base(canvas,"Fluid Resistance")
    {
        movers = new(); 

        for (int i=0; i< 10; i++)
        {
            float mass = Random.Shared.Next(1, 10);
            var shape = new Ellipse()
            {
                StrokeThickness = 2,
                Stroke = Brushes.Black,
                Fill = Brushes.LightGray
            };
            Mover m = new Mover(40 + i * (_width/10), 0, mass, shape);

            movers.Add(m);
        }

        liquid = new Fluid(new Boundary(0, 200, _width, _height), 0.2f);

        gravity = new Vector2(0, 0.1f);

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();

        Rectangle liquidShape = new Rectangle()
        {
            StrokeThickness = 1,
            Fill = Brushes.CustomAlfa(0,50,250,50),
            Height = liquid.Bounds.h,
            Width = liquid.Bounds.w
        };
        this._canvas.Children.Add(liquidShape);
        
        Canvas.SetTop(liquidShape, liquid.Bounds.y);

        foreach (var m in movers) 
            this._canvas.Children.Add(m.shape);
    }

    public override void Update(long delta)
    {
        //Gravity affects independient of the mass
        foreach (var m in movers) { 

            if (liquid.ContainsMover(m))
            {
                Vector2 dragForce = liquid.ClaculateDrag(m);
                m.ApplyForce(dragForce);
            }

            m.ApplyForce(Vector2.Multiply(gravity, m.GetMass));
            m.Update();
            m.Display();
            m.CheckEdges(boundary);
        }

        
    }



}