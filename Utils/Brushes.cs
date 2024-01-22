using System;
using System.Windows.Media;

public class Brushes
{

    public static SolidColorBrush White => new SolidColorBrush(Colors.White);
    public static SolidColorBrush Black => new SolidColorBrush(Colors.Black);
    public static SolidColorBrush LightGray => new SolidColorBrush(Colors.LightGray);

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