using System;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerDetailViewModel : ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public bool HasSelectedYouTubeViewer => _selectedYouTubeViewerStore.SelectedYouTubeViewer != null;
        public string Username => _selectedYouTubeViewerStore.SelectedYouTubeViewer?.Username ?? "Unknown";
        public string IsSubscribedDisplay => _selectedYouTubeViewerStore.SelectedYouTubeViewer?.IsSubscribed == true ? "Yes" : "No";
        public string IsMemberDisplay => _selectedYouTubeViewerStore.SelectedYouTubeViewer?.IsMember == true ? "Yes" : "No";

        public YouTubeViewerDetailViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;

            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
        }

        protected override void Dispose()
        {
            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;

            base.Dispose();
        }

        private void SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
