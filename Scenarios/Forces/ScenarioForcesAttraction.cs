using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;
using NatureOfCode.Models;
using natureofcode_wpf.Models;


public class ScenarioForcesAttraction : ScenarioBase
{
    private Mover mover;
    private Attractor attractor;

    public ScenarioForcesAttraction(Canvas canvas) : base(canvas,"Attraction")
    {
        var shapeAttractor = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        var shapeMover = new Ellipse()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };

        attractor = new Attractor(_width / 2, _height / 2, 5, shapeAttractor);
        mover = new Mover(_width/2, _height/4, 3, shapeMover);
        mover.ApplyForce(new Vector2(1.5f, 0));

    }

    public override void Setup()
    {
        this._canvas.Children.Clear();
        this._canvas.Children.Add(attractor.shape);
        this._canvas.Children.Add(mover.shape);

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

        Vector2 force = attractor.Attract(mover);
        mover.ApplyForce(force); 

        mover.Update();
        mover.Display();
    }



}