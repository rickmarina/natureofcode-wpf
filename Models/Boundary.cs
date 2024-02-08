namespace natureofcode_wpf.Models;

public struct Boundary
{
    public float x { get; private set; }
    public float y { get; private set; }
    public float w { get; private set; }
    public float h { get; private set; }

    public Boundary(float x, float y, float w, float h)
    {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
    }
}
