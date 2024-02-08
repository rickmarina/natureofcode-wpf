namespace natureofcode_wpf.Models;

public struct Boundary
{
    public float x { get; private set; }
    public float y { get; private set; }
    public float width { get; private set; }
    public float height { get; private set; }

    public Boundary(float x, float y, float width, float height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
}
