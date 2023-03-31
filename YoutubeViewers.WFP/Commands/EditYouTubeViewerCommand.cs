using System.Threading.Tasks;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class EditYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly EditYouTubeViewerViewModel _editYouTubeViewerViewModel;

        public EditYouTubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel, ModalNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            _editYouTubeViewerViewModel = editYouTubeViewerViewModel;
            _youTubeViewersStore = youTubeViewersStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            string username = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.Username;
            bool isSubscribed = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsSubscribed;
            bool isMember = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsMember;

            YouTubeViewer youTubeViewer = new YouTubeViewer(username, isSubscribed, isMember, _editYouTubeViewerViewModel.YouTubeViewerId);

            await _youTubeViewersStore.Update(youTubeViewer);

            _modalNavigationStore.Close();
        }
    }
}
