using System.Diagnostics;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;


public class ScenarioOscilationTest : ScenarioBase, IScenario
{
    private Mover mover;
    private double angle = 0;

    public ScenarioOscilationTest(Canvas canvas) : base(canvas, "Oscilation Test")
    {
        var shapeQuad = new Rectangle()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        mover = new Mover(_width/2, _height/2, 3, shapeQuad);

    }

    public void Draw()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(mover.shape);

    }

    public void Update(long delta)
    {
        mover.Rotate(angle);

        mover.Update();
        mover.Display();

        angle = (angle +1) % 360;

    }



}