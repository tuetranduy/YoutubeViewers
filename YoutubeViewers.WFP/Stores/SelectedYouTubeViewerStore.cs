using System;
using YoutubeViewers.WPF.Models;

namespace YoutubeViewers.WPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private YouTubeViewer _selectedYouTubeViewer;

        public YouTubeViewer SelectedYouTubeViewer
        {
            get => _selectedYouTubeViewer;

            set
            {
                _selectedYouTubeViewer = value;
                SelectedYouTubeViewerChanged?.Invoke();
            } 
        }

        public event Action SelectedYouTubeViewerChanged;

    }
}
