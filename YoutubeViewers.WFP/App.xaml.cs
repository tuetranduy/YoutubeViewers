using Microsoft.EntityFrameworkCore;
using System.Windows;
using YoutubeViewers.WPF.Stores;
using YoutubeViewers.WPF.ViewModels;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Commands;
using YouTubeViewers.EntityFramework.Queries;

namespace YoutubeViewers.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly YouTubeViewersDbContextFactory _youtubeViewersDbContextFactory;

        private readonly ICreateYouTubeViewerCommand _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand _deleteYouTubeViewerCommand;
        private readonly IGetAllYouTubeViewersQuery _getAllYouTubeViewersQuery;

        private YouTubeViewersStore _youTubeViewersStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            string _connectionString = "Data Source=localhost; Initial Catalog=ytsql-db; User Id=sa; Password=Password123; TrustServerCertificate=True";

            _youtubeViewersDbContextFactory = new YouTubeViewersDbContextFactory(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options);

            _createYouTubeViewerCommand = new CreateYouTubeViewerCommand(_youtubeViewersDbContextFactory);
            _updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(_youtubeViewersDbContextFactory);
            _deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(_youtubeViewersDbContextFactory);
            _getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(_youtubeViewersDbContextFactory);

            _youTubeViewersStore = new YouTubeViewersStore(_createYouTubeViewerCommand, _updateYouTubeViewerCommand, _deleteYouTubeViewerCommand, _getAllYouTubeViewersQuery);
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (YouTubeViewersDbContext context = _youtubeViewersDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(_youTubeViewersStore, _selectedYouTubeViewerStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
