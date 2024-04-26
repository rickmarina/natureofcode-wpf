using natureofcode_wpf.Models;
using natureofcode_wpf.Utils;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Numerics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Converters;
using System.Windows.Shapes;


namespace natureofcode_wpf.Scenarios.Oscilation
{
    internal class ScenarioAsteroids : ScenarioBase
    {
        Mover ship;

        public ScenarioAsteroids(Canvas canvas) : base(canvas, "Asteroids ship")
        {
            ShipShape shipShape = new ShipShape()
            {
                Width = 30,
                Height = 40,
                Stroke = Brushes.Black,
                Fill = Brushes.LightBlue,
                StrokeThickness = 1,
                RenderTransformOrigin = new System.Windows.Point(0.5, 0.5)

            };
            ship = new Mover(_width / 2, _height / 2, 1, shipShape);
            ship.topVelocity = 6;
            ship.damping = 0.995f;
        }
        public override void Setup()
        {
            this._canvas.ClipToBounds = true;
            this._canvas.Children.Clear();
            this._canvas.Children.Add(ship.shape);
        }

        public override void Update(long delta)
        {
            ship.shape.Fill = Brushes.LightGray;

            if (keyDown.Equals(Key.Z))
            {
                var force = Degrees.FromAngle(ship.GetAngle - (Math.PI / 2));
                force.SetMag(0.025f);
                ship.ApplyForce(force);

                ship.shape.Fill = Brushes.Red;

            } else if (keyDown.Equals(Key.Left)) {
                ship.ApplyAngularAcceleration(-0.01);
            } else if (keyDown.Equals(Key.Right))
            {
                ship.ApplyAngularAcceleration(0.01);
            }
            if (!keyUp.Equals(Key.None))
            {
                ship.StopAngleRotation();
            }

            ship.Update();
            WrapEdges();
            ship.Display();
        }

        public void WrapEdges()
        {
            if (ship.Position.X > _width + ship.shape.Width)
                ship.SetPosition(new Vector2((float)-ship.shape.Width, ship.Position.Y));
            else if (ship.Position.X < 0 - ship.shape.Width)
                ship.SetPosition(new Vector2(_width, ship.Position.Y));

            if (ship.Position.Y < 0 - ship.shape.Height)
            {
                float ny = (float)_height + (float)ship.shape.Height;
                ship.SetPosition(new Vector2(ship.Position.X, ny));
            }
            else if (ship.Position.Y > _height + ship.shape.Height)
                ship.SetPosition(new Vector2((float)ship.Position.X, (float)-ship.shape.Height));
        }
    }
}
