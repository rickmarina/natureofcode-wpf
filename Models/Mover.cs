﻿using System.Numerics;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace natureofcode_wpf.Models;
public class Mover
{
    private float mass; 
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 acceleration;
    public Shape shape { get; private set; } 

    public Mover(float x, float y, float mass, Shape shape) { 
        this.position = new Vector2(x, y);
        this.velocity = new Vector2(0, 0);
        this.acceleration = new Vector2(0, 0);
        this.mass = mass;
        this.shape = shape;
    }

    public void ApplyForce(Vector2 force) => this.acceleration = Vector2.Add(acceleration, Vector2.Divide(force, mass));

    public void Display()
    {
        Canvas.SetLeft(this.shape, this.position.X-20);
        Canvas.SetTop(this.shape, this.position.Y-20);
    }

    public void Update()
    {
        this.velocity = Vector2.Add(this.velocity, this.acceleration);
        this.position = Vector2.Add(this.position, this.velocity);

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

        if (this.position.Y > boundary.h)
        {
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(1, -1));
            this.position.Y = boundary.h;
        }
    }

}
