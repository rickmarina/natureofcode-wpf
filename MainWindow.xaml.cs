using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
            

        }

        private async void bStartAnimation_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Initializing animation..");

            if (!animated)
            {
                animated = true;
                scenario = new ScenarioVectorsNormalizing(canvas); // <---- Scenario
                this.Title = $"Nature of code [{scenario.GetTitle()}]";
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

            int fps = 0;
            long accMs = 0; 

            while (animated)
            {
                fps++;
                await Task.Delay(6);

                long elapsedMs = stopwatch.ElapsedMilliseconds;
                stopwatch.Restart();
                accMs += elapsedMs;
                if (accMs > 1000)
                {
                    this.Title = $"Nature of code [{scenario?.GetTitle()}] - fps: {fps}";
                    fps = 0;
                    accMs = 0; 
                }

                //Debug.WriteLine($"Loop Random Walker {elapsedMs}");

                scenario?.Update(elapsedMs);

            }

            Debug.WriteLine($"Fin loop");
        }

        private void bScreenshot_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)this.RenderSize.Width,(int)this.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);    
            rtb.Render(this);

            var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, (int)this.RenderSize.Width, (int)this.RenderSize.Height));

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            using (var fs = System.IO.File.OpenWrite($"screenshot_{DateTime.UtcNow.ToFileTime()}.png"))
            {
                pngEncoder.Save(fs);
            }
        }
    }
}
