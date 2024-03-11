using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Schema;
using NatureOfCode.Models;
public class ScenarioRandomNumberDistribution : ScenarioBase
{

    private List<Rectangle> _rects;

    private const int TOTAL = 20;

    public ScenarioRandomNumberDistribution(Canvas canvas) : base(canvas, "Random Number Distribution")
    {
        _rects = new();        
        for (int i = 0; i < TOTAL; i++)
        {

            var r = new Rectangle() { 
                    Width= this._width/TOTAL, 
                    Height=50, 
                    Fill = Brushes.LightGray,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

            Canvas.SetLeft(r, i*(this._width/TOTAL));
            Canvas.SetBottom(r, 0);
            

            _rects.Add(r);
        }

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        foreach (var r in _rects)
            this._canvas.Children.Add(r);
    }

    public override void Update(long delta)
    {
        int idx = Random.Shared.Next(TOTAL);

        this._rects[idx].Height++;

        
    }


    

    
}