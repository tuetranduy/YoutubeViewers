using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewerListingItemViewModel> _youTubeViewerListingItemViewModels;

        public IEnumerable<YouTubeViewerListingItemViewModel> YouTubeViewerListingItemViewModels => _youTubeViewerListingItemViewModels;

        public YouTubeViewerListingViewModel()
        {
            _youTubeViewerListingItemViewModels = new ObservableCollection<YouTubeViewerListingItemViewModel>
            {
                new YouTubeViewerListingItemViewModel("Tue"),
                new YouTubeViewerListingItemViewModel("Thanh"),
                new YouTubeViewerListingItemViewModel("Test123"),
                new YouTubeViewerListingItemViewModel("Test456")
            };
        }
    }
}
