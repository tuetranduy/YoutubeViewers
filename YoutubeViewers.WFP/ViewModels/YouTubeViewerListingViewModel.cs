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
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        private YouTubeViewerListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public IEnumerable<YouTubeViewerListingItemViewModel> YouTubeViewerListingItemViewModels => _youTubeViewerListingItemViewModels;


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

        public YouTubeViewerListingViewModel(YouTubeViewersStore youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewersStore = youTubeViewersStore;
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _modalNavigationStore = modalNavigationStore;

            _youTubeViewerListingItemViewModels = new ObservableCollection<YouTubeViewerListingItemViewModel>();

            _youTubeViewersStore.YouTubeViewerAdded += YouTubeViewersStore_YouTubeViewerAdded;
            _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;

        }

        private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }

        protected override void Dispose()
        {
            _youTubeViewersStore.YouTubeViewerAdded -= YouTubeViewersStore_YouTubeViewerAdded;
            _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;

            base.Dispose();
        }

        private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            var youTubeViewerViewModel = _youTubeViewerListingItemViewModels.FirstOrDefault(x => x.YouTubeViewer.Id == youTubeViewer.Id);

            youTubeViewerViewModel?.Update(youTubeViewer);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            _youTubeViewerListingItemViewModels.Add(new YouTubeViewerListingItemViewModel(youTubeViewer, _modalNavigationStore, _youTubeViewersStore));
        }
    }
}
