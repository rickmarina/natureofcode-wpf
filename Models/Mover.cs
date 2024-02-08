using System.Numerics;

namespace natureofcode_wpf.Models;
public class Mover
{
    public float mass { get; private set; } 
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 acceleration;

    public Mover(float x, float y, float mass = 1) { 
        this.position = new Vector2(x, y);
        this.velocity = new Vector2(0, 0);
        this.acceleration = new Vector2(0, 0);
        this.mass = mass;
    }

    public void ApplyForce(Vector2 force) => this.acceleration = Vector2.Add(acceleration, Vector2.Divide(force, mass));

    public void Update()
    {
        this.velocity = Vector2.Add(this.velocity, this.acceleration);
        this.position = Vector2.Add(this.position, this.velocity);

        this.acceleration = Vector2.Multiply(this.acceleration, 0);
    }
    public void CheckEdges(Boundary boundary)
    {
        if (this.position.X > boundary.width) {
            this.position.X = boundary.width;
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(-1, 0));
        }
        else if (this.position.X < boundary.x)
        {
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(-1, 0));
            this.position.X = 0;
        }

        if (this.position.Y > boundary.height)
        {
            this.velocity = Vector2.Multiply(this.velocity, new Vector2(0, -1));
            this.position.Y = boundary.height;
        }
    }

}
