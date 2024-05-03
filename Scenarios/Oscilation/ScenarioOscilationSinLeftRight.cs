using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using natureofcode_wpf.Utils;


public class ScenarioOscilationSinLeftRight : ScenarioBase
{
    private double period = 220;
    private double amplitude = 200;
    private double frameCount = 0; 

    private Ellipse circleSin;
    private Line lineSin;
    
    private Ellipse circleCos;
    private Line lineCos;

    public ScenarioOscilationSinLeftRight(Canvas canvas) : base(canvas, "Oscilation Sin Left-Right")
    {
        lineSin = new Line()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            X1 = -150,
            Y1 = 0, 
            X2 = 150, 
            Y2 = 0
        };

        circleSin = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };
        lineCos = new Line()
        {
            StrokeThickness = 2,
            Stroke = Brushes.Black,
            X1 = -150,
            Y1 = 0,
            X2 = 150,
            Y2 = 0
        };

        circleCos = new Ellipse()
        {
            StrokeThickness = 4,
            Stroke = Brushes.Black,
            Fill = Brushes.LightGray,
            Width = 40,
            Height = 40
        };



    }

    public override void Setup()
    {
        this._canvas.Children.Add(lineSin);
        this._canvas.Children.Add(circleSin);
        this._canvas.Children.Add(lineCos);
        this._canvas.Children.Add(circleCos);
        _canvas.RenderTransform = Translate(_width / 2, _height / 2);

    }

    public override void Update(long delta)
    {
        double xSin = amplitude * Math.Sin(Math.PI * 2 * (frameCount / period));
        double xCos = amplitude * Math.Cos(Math.PI * 2 * (frameCount / period));

        circleSin.RenderTransform = Translate(xSin, -20);
        lineSin.X1 = 0;
        lineSin.Y1 = 0;
        lineSin.X2 = xSin;
        lineSin.Y2 = 0;

        circleCos.RenderTransform = Translate(xCos,40);
        lineCos.X1 = 0;
        lineCos.Y1 = 60;
        lineCos.X2 = xCos;
        lineCos.Y2 = 60;

        frameCount++;

    }



}