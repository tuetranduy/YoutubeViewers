using YoutubeViewers.Domain.Models;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class OpenEditYouTubeViewerCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly YouTubeViewerListingItemViewModel _youTubeViewerListingItemViewModel;

        public OpenEditYouTubeViewerCommand(YouTubeViewerListingItemViewModel youTubeViewerListingItemViewModel, ModalNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewerListingItemViewModel = youTubeViewerListingItemViewModel;
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override void Execute(object parameter)
        {
            YouTubeViewer youTubeViewer = _youTubeViewerListingItemViewModel.YouTubeViewer;

            EditYouTubeViewerViewModel editYouTubeViewerViewModel = new EditYouTubeViewerViewModel(youTubeViewer, _modalNavigationStore, _youTubeViewersStore);

            _modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
        }

    }
}
