using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NatureOfCode.Models;
public class ScenarioVectorsBouncingBall : ScenarioBase, IScenario
{

    Vector2 position;
    Vector2 velocity;
    Ellipse ball; 

    public ScenarioVectorsBouncingBall(Canvas canvas) : base(canvas,"Bouncing balls with vectors")
    {
        position = new Vector2(100, 100); 
        velocity = new Vector2(2.5f, 2);

        ball = new Ellipse()
        {
            Width = 40,
            Height = 40,
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray
        };


    }

    public void Draw()
    {
        this._canvas.Children.Clear();

        this._canvas.Children.Add(ball);
    }

    public void Update(long delta)
    {
        
        position = Vector2.Add(velocity, position);

        if (position.X+20 > _width || position.X+20 < 0)
            velocity.X *= -1;
        if (position.Y+20 > _height || position.Y+20 < 0)
            velocity.Y *= -1;

        Canvas.SetLeft(ball, position.X);
        Canvas.SetTop(ball, position.Y);


    }


 
}