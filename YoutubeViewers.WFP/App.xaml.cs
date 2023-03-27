using System.Windows;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new YouTubeViewersViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        #endregion
    }
}
