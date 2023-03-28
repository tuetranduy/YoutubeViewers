using System.Windows.Input;
using YoutubeViewers.WPF.Models;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; }

        public string Username => YouTubeViewer.Username;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YouTubeViewerListingItemViewModel(YouTubeViewer youTubeViewer)
        {
            YouTubeViewer = youTubeViewer;
        }
    }
}
