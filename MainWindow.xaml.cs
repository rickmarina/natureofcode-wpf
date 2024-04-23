using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using NatureOfCode.Models;
using natureofcode_wpf.Scenarios.CodingTrain;
using natureofcode_wpf.Scenarios.Oscilation;

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
            Console.WriteLine($"Setup animation..");

            if (!animated)
            {
                animated = true;
                scenario = new ScenarioPolarToCartesian(canvas); // <---- Scenario
                this.Title = $"Nature of code [{scenario.GetTitle()}]";
                scenario?.Setup();
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
                    fpsValue.Content = fps;
                    fps = 0;
                    accMs = 0; 
                }

                //Update scenario frame
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
