using System.Windows.Input;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewerListingViewModel YouTubeViewerListingViewModel { get; }

        public YouTubeViewerDetailViewModel YouTubeViewerDetailViewModel { get; }

        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            YouTubeViewerDetailViewModel = new YouTubeViewerDetailViewModel(selectedYouTubeViewerStore);
            YouTubeViewerListingViewModel = new YouTubeViewerListingViewModel(selectedYouTubeViewerStore);
        }
    }
}
