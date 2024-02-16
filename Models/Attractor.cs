using natureofcode_wpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace natureofcode_wpf.Models
{
    public class Attractor
    {
        private float mass;
        private Vector2 position;
        private float radio;
        public Shape shape { get; private set; }
        public const float G = 1.0f;
        public bool dragging = false;
        public Vector2 dragOffset = new Vector2(0, 0);
        public bool rollover = false;

        public Attractor(float x, float y, float mass, Shape shape)
        {
            this.position = new Vector2(x, y);
            this.mass = mass;
            this.shape = shape;

            this.shape.Width = mass * 12;
            this.shape.Height = mass * 12;

            this.radio = mass * 6;
        }

        public void Display()
        {
            if (dragging)
                this.shape.Fill = Brushes.BlackAlfa(80);
            else if (rollover)
                this.shape.Fill = Brushes.BlackAlfa(60);
            else
                this.shape.Fill = Brushes.LightGray;

            Canvas.SetLeft(this.shape, this.position.X - this.shape.Width / 2);
            Canvas.SetTop(this.shape, this.position.Y - this.shape.Width / 2);
        }

        public Vector2 Attract(Mover m)
        {
            Vector2 force = Vector2.Subtract(this.position, m.Position);
            float distance = force.Length();

            distance = Math.Max(5, Math.Min(25, distance));

            float strength = (G * this.mass * m.GetMass) / (distance * distance);
            force.SetMag(strength);
            return force;
        }

        public void HandleHover(double x, double y)
        {
            float dist = Vector2.Distance(new Vector2((float)x,(float)y), this.position);

            if (dist < radio)
                rollover = true; 
            else 
                rollover = false;

        }
        public void HandleDragged(double x, double y)
        {
            if (dragging)
            {
                Vector2 mouse = new Vector2((float)x,(float)y);
                this.position = Vector2.Add(mouse, this.dragOffset);
            }
        }

        public void HandlePress(double x, double y)
        {
            float dist = Vector2.Distance(new Vector2((float)x, (float)y), this.position);
            if (dist < radio)
            {
                dragging = true;
                this.dragOffset.X = this.position.X - (float)x;
                this.dragOffset.Y = this.position.Y - (float)y;
            }

        }

        public void StopDragging()
        {
            this.dragging = false; 
        }
    }
}
