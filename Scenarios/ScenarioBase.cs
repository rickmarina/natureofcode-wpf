using NatureOfCode.Models;
using natureofcode_wpf.Models;
using System;
using System.Windows.Controls;
using System.Windows.Media;

public abstract class ScenarioBase : IScenario
{
    protected readonly Canvas _canvas;
    protected readonly int _height;
    protected readonly int _width;
    protected readonly string _title;
    protected Boundary boundary; 
    protected bool mouseLeftPressed = false;
    protected bool mouseLeftReleased = false; 
    protected bool mouseMove = false;
    protected bool mouseDragg = false; 
    protected double mouseX;
    protected double mouseY; 

    public ScenarioBase(Canvas canvas, string title)
    {
        _canvas = canvas;
        this._width = Convert.ToInt32(_canvas.ActualWidth);
        this._height = Convert.ToInt32(_canvas.ActualHeight);

        this.boundary = new Boundary(0,0,this._width, this._height);

        this._title = title;

        this._canvas.MouseLeftButtonDown += _canvas_MouseLeftButtonDown;
        this._canvas.MouseLeftButtonUp += _canvas_MouseLeftButtonUp;
        this._canvas.MouseMove += _canvas_MouseMove;
    }

    private void _canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        if (mouseLeftPressed)
            mouseDragg = true; 
        else 
            mouseMove = true;
        mouseX = e.MouseDevice.GetPosition(this._canvas).X;
        mouseY = e.MouseDevice.GetPosition(this._canvas).Y;
    }

    private void _canvas_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        mouseMove = false;
        mouseLeftPressed = false;
        mouseLeftReleased = true;
        mouseX = e.MouseDevice.GetPosition(this._canvas).X;
        mouseY = e.MouseDevice.GetPosition(this._canvas).Y;
    }

    private void _canvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        mouseMove = false;
        mouseLeftPressed = true;
        mouseLeftReleased = false;
        mouseX = e.MouseDevice.GetPosition(this._canvas).X;
        mouseY = e.MouseDevice.GetPosition(this._canvas).Y;
    }


    public string GetTitle() => this._title;

    protected TranslateTransform Translate(double x, double y) => new TranslateTransform(x, y); // Translate origin

    public abstract void Setup();
    public abstract void Update(long delta);

}