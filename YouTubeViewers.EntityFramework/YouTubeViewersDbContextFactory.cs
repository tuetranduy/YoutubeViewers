using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YouTubeViewers.EntityFramework
{
    public class YouTubeViewersDesignTimeDbContextFactory : IDesignTimeDbContextFactory<YouTubeViewersDbContext>
    {
        public YouTubeViewersDbContext CreateDbContext(string[] args = null)
        {
            return new YouTubeViewersDbContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=localhost; Initial Catalog=ytsql-db; User Id=sa; Password=Password123; TrustServerCertificate=True").Options);
        }
    }
}
