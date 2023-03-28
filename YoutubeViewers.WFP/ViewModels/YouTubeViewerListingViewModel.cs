using System.Collections.Generic;
using System.Collections.ObjectModel;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewerListingItemViewModel> _youTubeViewerListingItemViewModels;

        public IEnumerable<YouTubeViewerListingItemViewModel> YouTubeViewerListingItemViewModels => _youTubeViewerListingItemViewModels;

        public YouTubeViewerListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _youTubeViewerListingItemViewModels = new ObservableCollection<YouTubeViewerListingItemViewModel>();

            _youTubeViewerListingItemViewModels.Add(new YouTubeViewerListingItemViewModel("Tue"));
            _youTubeViewerListingItemViewModels.Add(new YouTubeViewerListingItemViewModel("Thanh"));
            _youTubeViewerListingItemViewModels.Add(new YouTubeViewerListingItemViewModel("Son"));
            _youTubeViewerListingItemViewModels.Add(new YouTubeViewerListingItemViewModel("Admin"));
            _youTubeViewerListingItemViewModels.Add(new YouTubeViewerListingItemViewModel("123"));
        }
    }
}
