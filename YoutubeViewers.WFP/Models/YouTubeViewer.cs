using System;

namespace YoutubeViewers.WPF.Models
{
    public class YouTubeViewer
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(string username, bool isSubscribed, bool isMember, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
