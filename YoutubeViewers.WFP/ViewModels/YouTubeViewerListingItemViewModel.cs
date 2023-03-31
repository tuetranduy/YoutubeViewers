using System.Windows.Input;
using YoutubeViewers.WPF.Commands;
using YoutubeViewers.WPF.Models;
using YoutubeViewers.WPF.Stores;

namespace YoutubeViewers.WPF.ViewModels;

public class YouTubeViewerListingItemViewModel : ViewModelBase
{
    public YouTubeViewer YouTubeViewer { get; private set; }

    public string Username => YouTubeViewer.Username;

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public YouTubeViewerListingItemViewModel(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore, YouTubeViewersStore youTubeViewersStore)
    {
        YouTubeViewer = youTubeViewer;
        EditCommand = new OpenEditYouTubeViewerCommand(this, modalNavigationStore, youTubeViewersStore);
    }

    public void Update(YouTubeViewer youTubeViewer)
    {
        YouTubeViewer = youTubeViewer;

        OnPropertyChanged(nameof(Username));
    }
}