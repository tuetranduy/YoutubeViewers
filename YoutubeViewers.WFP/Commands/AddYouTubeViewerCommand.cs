using System;
using System.Threading.Tasks;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;

namespace YoutubeViewers.WPF.Commands
{
    public class AddYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;

        public AddYouTubeViewerCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersStore = youTubeViewersStore;
            _addYouTubeViewerViewModel = addYouTubeViewerViewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            string username = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.Username;
            bool isSubscribed = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsSubscribed;
            bool isMember = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsMember;

            YouTubeViewer youTubeViewer = new YouTubeViewer( username, isSubscribed, isMember, Guid.NewGuid());

            try
            {
                await _youTubeViewersStore.Add(youTubeViewer);

                _modalNavigationStore.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
