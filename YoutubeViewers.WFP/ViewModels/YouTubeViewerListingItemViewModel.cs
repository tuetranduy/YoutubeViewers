using System.Windows.Input;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerListingItemViewModel : ViewModelBase
    {
        public string Username { get; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YouTubeViewerListingItemViewModel(string username)
        {
            Username = username;
        }
    }
}
