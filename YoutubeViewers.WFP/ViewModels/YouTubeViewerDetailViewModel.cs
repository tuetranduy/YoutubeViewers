using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerDetailViewModel : ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public string Username => _selectedYouTubeViewerStore.SelectedYouTubeViewer?.Username;
        public string IsSubscribedDisplay => _selectedYouTubeViewerStore.SelectedYouTubeViewer?.IsSubscribed == true ? "Yes" : "No";
        public string IsMemberDisplay => _selectedYouTubeViewerStore.SelectedYouTubeViewer?.IsMember == true ? "Yes" : "No";

        public YouTubeViewerDetailViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
        }
    }
}
