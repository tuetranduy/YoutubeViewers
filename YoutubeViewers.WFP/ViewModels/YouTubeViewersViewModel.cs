using System.Windows.Input;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewerListingViewModel YouTubeViewerListingViewModel { get; }

        public YouTubeViewerDetailViewModel YouTubeViewerDetailViewModel { get; }

        public ICommand AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(YouTubeViewersStore youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewerDetailViewModel = new YouTubeViewerDetailViewModel(selectedYouTubeViewerStore);
            YouTubeViewerListingViewModel = new YouTubeViewerListingViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(modalNavigationStore, youTubeViewersStore);
        }
    }
}
