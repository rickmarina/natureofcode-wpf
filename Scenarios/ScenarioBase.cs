using natureofcode_wpf.Models;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;

public abstract class ScenarioBase
{
    protected readonly Canvas _canvas;
    protected readonly int _height;
    protected readonly int _width;
    protected readonly string _title;
    protected Boundary boundary; 
    protected bool mouseLeftPressed = false; 

    public ScenarioBase(Canvas canvas, string title)
    {
        _canvas = canvas;
        this._width = Convert.ToInt32(_canvas.ActualWidth);
        this._height = Convert.ToInt32(_canvas.ActualHeight);

        this.boundary = new Boundary(0,0,this._width, this._height);

        this._title = title;

        this._canvas.MouseLeftButtonDown += _canvas_MouseLeftButtonDown;
        this._canvas.MouseLeftButtonUp += _canvas_MouseLeftButtonUp;
    }

    private void _canvas_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        mouseLeftPressed = false;
    }

    private void _canvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        mouseLeftPressed = true;
    }


    public string GetTitle() => this._title;

    

    protected TranslateTransform Translate(double x, double y) => new TranslateTransform(x, y); // Translate origin

}