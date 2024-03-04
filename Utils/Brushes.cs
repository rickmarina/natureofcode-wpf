using System;
using System.Windows.Media;

public class Brushes
{

    public static SolidColorBrush White => new SolidColorBrush(Colors.White);
    public static SolidColorBrush Black => new SolidColorBrush(Colors.Black);
    public static SolidColorBrush BlackAlfa(double alfa) => new SolidColorBrush(Color.FromArgb((byte)alfa, 0,0,0));
    public static SolidColorBrush LightGray => new SolidColorBrush(Colors.LightGray);
    public static SolidColorBrush LightBlue() => new SolidColorBrush(Colors.LightBlue);
    public static SolidColorBrush Red => new SolidColorBrush(Colors.Red);
    public static SolidColorBrush CustomAlfa(byte r, byte g, byte b, byte a) => new SolidColorBrush(Color.FromArgb(a, r,g,b));
    public static SolidColorBrush Random()
    {
        Random rnd = new Random();
        byte[] rgb = new byte[3];
        rnd.NextBytes(rgb);

        Color randomColor = Color.FromRgb(rgb[0], rgb[1], rgb[2]);
        SolidColorBrush randomColorBrush = new SolidColorBrush(randomColor);

        return randomColorBrush;
    }

}