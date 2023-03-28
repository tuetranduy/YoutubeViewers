using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewerListingItemViewModel> _youTubeViewerListingItemViewModels;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public IEnumerable<YouTubeViewerListingItemViewModel> YouTubeViewerListingItemViewModels => _youTubeViewerListingItemViewModels;

        private YouTubeViewerListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public YouTubeViewerListingItemViewModel SelectedYouTubeViewerListingItemViewModel
        {
            get => _selectedYouTubeViewerListingItemViewModel;

            set
            {
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }

        }

        public YouTubeViewerListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _youTubeViewerListingItemViewModels = new ObservableCollection<YouTubeViewerListingItemViewModel>
            {
                new YouTubeViewerListingItemViewModel(new YouTubeViewer("Tue", true, false)),
                new YouTubeViewerListingItemViewModel(new YouTubeViewer("Thanh", true, true)),
                new YouTubeViewerListingItemViewModel(new YouTubeViewer("Test", false, false))
            };
        }
    }
}
