using System;
using System.Windows.Controls;

public abstract class ScenarioBase
{
    protected readonly Canvas _canvas;
    protected readonly int _height;
    protected readonly int _width;
    protected readonly string _title; 

    public ScenarioBase(Canvas canvas, string title)
    {
        _canvas = canvas;
        this._width = Convert.ToInt32(_canvas.ActualWidth);
        this._height = Convert.ToInt32(_canvas.ActualHeight);
        this._title = title;
    }

    public string GetTitle() => this._title;


}