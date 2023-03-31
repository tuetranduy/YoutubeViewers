using System.Threading.Tasks;
using YoutubeViewers.Domain.Models;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class DeleteYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly YouTubeViewerListingItemViewModel _youTubeViewerListingItemViewModel;

        public DeleteYouTubeViewerCommand(YouTubeViewerListingItemViewModel youTubeViewerListingItemViewModel, YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewerListingItemViewModel = youTubeViewerListingItemViewModel;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            YouTubeViewer youTubeViewer = _youTubeViewerListingItemViewModel.YouTubeViewer;

            await _youTubeViewersStore.Delete(youTubeViewer.Id);
        }
    }
}
