using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeViewers.Domain.Models;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;

namespace YoutubeViewers.WPF.Stores
{
    public class YouTubeViewersStore
    {
        private readonly ICreateYouTubeViewerCommand _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand _deleteYouTubeViewerCommand;
        private readonly IGetAllYouTubeViewersQuery _getAllYouTubeViewersQuery;

        private readonly List<YouTubeViewer> _youTubeViewers;

        public event Action<YouTubeViewer> YouTubeViewerAdded;
        public event Action<YouTubeViewer> YouTubeViewerUpdated;
        public event Action<Guid> YouTubeViewerDeleted;
        public event Action YouTubeViewerLoaded;

        public IEnumerable<YouTubeViewer> YouTubeViewers => _youTubeViewers;

        public YouTubeViewersStore(ICreateYouTubeViewerCommand createYouTubeViewerCommand, IUpdateYouTubeViewerCommand updateYouTubeViewerCommand, IDeleteYouTubeViewerCommand deleteYouTubeViewerCommand, IGetAllYouTubeViewersQuery getAllYouTubeViewersQuery)
        {
            _createYouTubeViewerCommand = createYouTubeViewerCommand;
            _updateYouTubeViewerCommand = updateYouTubeViewerCommand;
            _deleteYouTubeViewerCommand = deleteYouTubeViewerCommand;
            _getAllYouTubeViewersQuery = getAllYouTubeViewersQuery;

            _youTubeViewers = new List<YouTubeViewer>();

            YouTubeViewerLoaded?.Invoke();
        }

        public async Task Load()
        {
            IEnumerable<YouTubeViewer> youTubeViewers = await _getAllYouTubeViewersQuery.Execute();

            _youTubeViewers.Clear();
            _youTubeViewers.AddRange(youTubeViewers);

            YouTubeViewerLoaded?.Invoke();
        }


        public async Task Add(YouTubeViewer youTubeViewer)
        {
            await _createYouTubeViewerCommand.Execute(youTubeViewer);

            _youTubeViewers.Add(youTubeViewer);

            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            await _updateYouTubeViewerCommand.Execute(youTubeViewer);

            int currentIndex = _youTubeViewers.FindIndex(x => x.Id == youTubeViewer.Id);

            if (currentIndex != -1)
            {
                _youTubeViewers[currentIndex] = youTubeViewer;
            }
            else
            {
                _youTubeViewers.Add(youTubeViewer);
            }

            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }

        public async Task Delete(Guid id)
        {
            await _deleteYouTubeViewerCommand.Execute(id);

            _youTubeViewers.RemoveAll(x => x.Id == id);

            YouTubeViewerDeleted?.Invoke(id);
        }
    }
}
