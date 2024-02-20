using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;


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