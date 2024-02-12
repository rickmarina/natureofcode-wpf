using natureofcode_wpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace natureofcode_wpf.Models
{
    public class Fluid
    {
        public float Coeficient { get; private set; }
        public Boundary Bounds { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="boundary"></param>
        /// <param name="coeficient">coeficient of drag</param>
        public Fluid(Boundary boundary, float coeficient)
        {
            Bounds = boundary;
            Coeficient = coeficient;
        }


        public bool ContainsMover(Mover mov)
        {
            return (mov.Position.X > Bounds.x && mov.Position.X < Bounds.x+Bounds.w &&
                mov.Position.Y > Bounds.y && mov.Position.Y < Bounds.y+Bounds.h);
        }

        public Vector2 ClaculateDrag(Mover mov)
        {
            float speed = mov.Velocity.Length();
            float dragMagnitude = Coeficient * speed * speed;
            Vector2 dragForce = Vector2.Multiply(mov.Velocity,- 1);
            dragForce.SetMag(dragMagnitude);

            return dragForce;
        }
    }
}
