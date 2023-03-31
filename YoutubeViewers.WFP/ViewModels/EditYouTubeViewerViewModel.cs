using System;
using System.Windows.Input;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.Domain.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels
{
    public class EditYouTubeViewerViewModel : ViewModelBase
    {
        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

        public Guid YouTubeViewerId { get; }

        public EditYouTubeViewerViewModel(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
        {
            YouTubeViewerId = youTubeViewer.Id;

            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ICommand submitCommand = new EditYouTubeViewerCommand(this, modalNavigationStore, youTubeViewersStore);

            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Username = youTubeViewer.Username,
                IsSubscribed = youTubeViewer.IsSubscribed,
                IsMember = youTubeViewer.IsMember
            };
        }
    }
}
