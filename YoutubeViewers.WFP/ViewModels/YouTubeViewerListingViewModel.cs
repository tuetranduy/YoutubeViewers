using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using YoutubeViewers.Domain.Models;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerListingViewModel : ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        private readonly ObservableCollection<YouTubeViewerListingItemViewModel> _youTubeViewerListingItemViewModels;
        private YouTubeViewerListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public IEnumerable<YouTubeViewerListingItemViewModel> YouTubeViewerListingItemViewModels => _youTubeViewerListingItemViewModels;

        public ICommand LoadYouTubeViewersCommand { get; }

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
            _youTubeViewersStore.YouTubeViewerLoaded += YouTubeViewersStore_YouTubeViewerLoaded;
            _youTubeViewersStore.YouTubeViewerDeleted += YouTubeViewersStore_YouTubeViewerDeleted;

            LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(youTubeViewersStore);
        }

        private void YouTubeViewersStore_YouTubeViewerDeleted(Guid id)
        {
            YouTubeViewerListingItemViewModel itemViewModel = _youTubeViewerListingItemViewModels.FirstOrDefault(x => x.YouTubeViewer.Id == id);

            _youTubeViewerListingItemViewModels.Remove(itemViewModel);
        }

        public static YouTubeViewerListingViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewerListingViewModel viewModel = new YouTubeViewerListingViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

            viewModel.LoadYouTubeViewersCommand.Execute(null);

            return viewModel;
        }

        private void YouTubeViewersStore_YouTubeViewerLoaded()
        {
            _youTubeViewerListingItemViewModels.Clear();

            foreach (YouTubeViewer youTubeViewer in _youTubeViewersStore.YouTubeViewers)
            {
                AddYouTubeViewer(youTubeViewer);
            }
        }

        private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
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

        protected override void Dispose()
        {
            _youTubeViewersStore.YouTubeViewerAdded -= YouTubeViewersStore_YouTubeViewerAdded;
            _youTubeViewersStore.YouTubeViewerUpdated -= YouTubeViewersStore_YouTubeViewerUpdated;
            _youTubeViewersStore.YouTubeViewerLoaded -= YouTubeViewersStore_YouTubeViewerLoaded;
            _youTubeViewersStore.YouTubeViewerDeleted -= YouTubeViewersStore_YouTubeViewerDeleted;

            base.Dispose();
        }
    }
}
