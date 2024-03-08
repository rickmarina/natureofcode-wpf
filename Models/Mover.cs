using natureofcode_wpf.Utils;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace natureofcode_wpf.Models;
public class Mover
{
    public const float G = 1.0f;
    private float mass; 
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 acceleration;
    private double angle = 0;
    private double angleVelocity = 0;
    private double angleAcceleration = 0;
    public Shape shape { get; private set; } 

    public Mover(float x, float y, float mass, Shape shape) { 
        this.position = new Vector2(x, y);
        this.velocity = new Vector2(0, 0);
        this.acceleration = new Vector2(0, 0);
        this.mass = mass;
        this.shape = shape;

        if (shape is not Circle) { 
            this.shape.Width = mass * 12;
            this.shape.Height = mass * 12;
        }
    }

    public void SetPosition(Vector2 pos)
    {
        this.position = pos;
    }

    public float GetMass => this.mass;
    public Vector2 Position => this.position;
    public Vector2 Velocity => this.velocity;
    public Vector2 Acceleration => this.acceleration;

    public void ApplyForce(Vector2 force) => this.acceleration = Vector2.Add(acceleration, Vector2.Divide(force, mass));
    public void ApplyAngularAcceleration(double a) => this.angleAcceleration = a;

    public void Display()
    {
        Canvas.SetLeft(this.shape, this.position.X-this.shape.Width/2);
        Canvas.SetTop(this.shape, this.position.Y- this.shape.Width / 2);
        Rotate(this.angle);
    }

    //Rotate radians 
    public void Rotate(double angle)
    {
        //this.shape.RenderTransformOrigin = new Point(0, 0);
        this.shape.RenderTransform = new RotateTransform(Degrees.RadiansToDegrees(angle));
    }
    public void Update()
    {
        this.velocity = Vector2.Add(this.velocity, this.acceleration);
        this.position = Vector2.Add(this.position, this.velocity);

        this.angleVelocity += this.angleAcceleration;
        this.angleVelocity = ScenarioMath.Constrain(this.angleVelocity, -0.1, 0.1);
        this.angle += this.angleVelocity;

        this.acceleration = Vector2.Multiply(this.acceleration, 0);
    }
    public void CheckEdges(Boundary boundary)
    {
        if (this.position.X > boundary.w) {
            this.position.X = boundary.w;
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(-1, 1));
        }
        else if (this.position.X < boundary.x)
        {
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(-1, 1));
            this.position.X = 0;
        }

        if (this.position.Y > boundary.h - (this.shape.Height/2))
        {
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(1, -1));
            this.position.Y = boundary.h - (float)(this.shape.Height/2);
        }
    }

    public bool ContactEdge(Boundary b)
    {
        return (this.position.Y > b.h - (this.shape.Width / 2)- 1);
    }

    public void BoundeEdges(Boundary b)
    {
        float bounce = -0.9f;
        if (this.position.Y > b.h - (this.shape.Width / 2))
        {
            this.position.Y = b.h - (float)(this.shape.Width / 2);
            this.velocity.Y *= bounce;
        }
    }

    public Vector2 Attract(Mover m)
    {
        Vector2 force = Vector2.Subtract(this.position, m.Position);
        float distance = force.Length();

        distance = Math.Max(5, Math.Min(25, distance)); //constraint distance in order to avoid very high distance with no effect and near zero edge case

        float strength = (G * this.mass * m.GetMass) / (distance * distance);
        force.SetMag(strength);
        return force;
    }

}
