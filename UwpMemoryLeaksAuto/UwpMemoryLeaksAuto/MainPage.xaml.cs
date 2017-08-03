using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpMemoryLeaksAuto
{
    public sealed partial class MainPage : Page
    {
        private bool running;
        private CancellationTokenSource tokenSource;

        public MainPage()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            StartSequenceAsync();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
                tokenSource = null;
            }
        }

        private void gc_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect(2, GCCollectionMode.Forced, true);
            GC.WaitForPendingFinalizers();
        }

        private async void StartSequenceAsync()
        {
            if (running)
            {
                return;
            }

            running = true;

            const int PagesPerLoop = 40;
            var start = DateTime.Now;
            int loopCount = 0;
            int pageCount = 0;

            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    loopCount++;

                    for (int i=0; i < PagesPerLoop; i++)
                    {
                        container.Content = new ContentPage();
                        pageCount++;
                        await Task.Delay(150, token);
                    }

                    container.Content = null;

                    await Task.Delay(5000, token);

                    GC.Collect(2, GCCollectionMode.Forced, true);
                    GC.WaitForPendingFinalizers();

                    await Task.Delay(2000, token);
                }
            }
            catch (TaskCanceledException)
            {
                // Just ignore, this is expected.
            }
            finally
            {
                var end = DateTime.Now;

                Debug.WriteLine($"End of test, loops {loopCount}");
                Debug.WriteLine($"Total time {(end - start).Seconds} seconds");
                Debug.WriteLine($"Number of pages created: {pageCount}");

                container.Content = null;
                tokenSource = null;
                running = false;
            }
        }
    }
}
