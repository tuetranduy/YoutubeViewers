using System.Windows.Input;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YouTubeViewerDetailsFormViewModel : ViewModelBase
    {
        private string _username;
        private bool _isSubscribed;
        private bool _isMember;

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public bool CanSubmit => !string.IsNullOrEmpty(Username);

        public YouTubeViewerDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

        public string Username
		{
			get => _username;
            set
			{
                _username = value;
				OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSubmit));
			}
		}

		public bool IsSubscribed
		{
			get => _isSubscribed;
            set
			{
				_isSubscribed = value;
				OnPropertyChanged(nameof(IsSubscribed));
			}
		}

        public bool IsMember
        {
            get => _isMember;
            set
            {
                _isMember = value;
                OnPropertyChanged(nameof(IsMember));
            }
        }
    }
}
