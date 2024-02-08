using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NatureOfCode.Models;
public class ScenarioPerlinNoise2D : ScenarioBase, IScenario
{
    private double time; 
    public ScenarioPerlinNoise2D(Canvas canvas) : base(canvas,"Perlin Noise 2D")
    {
        time = Random.Shared.NextDouble()*1000;
    }

    public void Draw()
    {
        this._canvas.Children.Clear();

        DrawingVisual dv = new DrawingVisual();
        using (DrawingContext dc = dv.RenderOpen()) {

            Random rand = new Random();

            double xoff = time; 

            for (int i = 0; i < _width; i++) {
                double yoff = 0;
                for (int j=0;j < _height; j++) {
                    double bright = PerlinNoise.Noise01(xoff, yoff, xoff) * 255;
                    dc.DrawRectangle(Brushes.BlackAlfa(bright), null, new Rect(i, j, 1, 1));
                    yoff += 0.005;

                }
                xoff += 0.005;
            }
        }

        RenderTargetBitmap rtb = new RenderTargetBitmap(_width, _height, 96, 96, PixelFormats.Pbgra32);
        rtb.Render(dv);
        Image img = new Image() { Source = rtb };

        this._canvas.Children.Add(img);
    }

    public void Update(long delta)
    {

    }


 
}