using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class OpenAddYouTubeViewerCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public OpenAddYouTubeViewerCommand(ModalNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override void Execute(object parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_youTubeViewersStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}
