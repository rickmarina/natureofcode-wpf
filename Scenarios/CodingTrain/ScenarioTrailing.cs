using NatureOfCode.Models;
using natureofcode_wpf.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace natureofcode_wpf.Scenarios.CodingTrain
{
    internal class ScenarioTrailing : ScenarioBase, IScenario
    {
        Mover mov;
        Queue<Mover> queue;


        public ScenarioTrailing(Canvas canvas) : base(canvas, "Trailing")
        {
            Ellipse ball = new Ellipse()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.LightBlue

            };
            mov = new Mover(Random.Shared.Next(_width / 2), Random.Shared.Next(_height / 2), 5, ball);

            queue = new();
            for (int i = 0; i < 1000; i++) {
                Ellipse trailshape = new Ellipse()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = Brushes.LightGray

                };
                var m = new Mover(mov.Position.X, mov.Position.Y, mov.GetMass, trailshape);
                queue.Enqueue(m);
            }


        }

        public void Draw()
        {
            _canvas.Children.Clear();

            foreach (var m in queue)
            {
                _canvas.Children.Add(m.shape);
                m.Display();
            }

            _canvas.Children.Add(mov.shape);
        }

        public void Update(long delta)
        {
            mov.ApplyForce(new System.Numerics.Vector2(0.01f, 0.05f));

            mov.Update();
            mov.CheckEdges(boundary);
            mov.Display();

            var front = queue.Dequeue();
            _canvas.Children.Remove(front.shape); // remove from canvas to reset z-index
            _canvas.Children.Add(front.shape);
            front.SetPosition(mov.Position);
            queue.Enqueue(front);
            front.Display();
            


        }
    }
}
