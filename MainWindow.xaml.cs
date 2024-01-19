using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NatureOfCode.Models;

namespace natureofcode_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool animated = false;
        private IScenario? scenario;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            scenario = new ScenarioRandomWalker8Directions(canvas);
        }

        private async void bStartAnimation_Click(object sender, RoutedEventArgs e)
{
    if (!animated) { 
        animated = true; 
        scenario?.Draw();
        await Loop();
    }
}

private void bStopAnimation_Click(object sender, RoutedEventArgs e)
{
    animated = false; 
    canvas.Children.Clear();
}

public async Task Loop()
{

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    while (animated)
    {
        await Task.Delay(50);

        long elapsedMs = stopwatch.ElapsedMilliseconds;
        stopwatch.Restart();

        //Debug.WriteLine($"Loop Random Walker {elapsedMs}");

        scenario?.Update(elapsedMs);

    }

    Debug.WriteLine($"Fin loop random walker");
}
    }
}
