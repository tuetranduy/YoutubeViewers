using System.Windows.Input;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewerListingViewModel YouTubeViewerListingViewModel { get; }

        public YouTubeViewerDetailViewModel YouTubeViewerDetailViewModel { get; }

        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel()
        {
            YouTubeViewerDetailViewModel = new YouTubeViewerDetailViewModel();
            YouTubeViewerListingViewModel = new YouTubeViewerListingViewModel();
        }
    }
}
