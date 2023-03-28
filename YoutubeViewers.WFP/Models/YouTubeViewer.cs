﻿namespace YoutubeViewers.WPF.Models
{
    public class YouTubeViewer
    {
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(string username, bool isSubscribed, bool isMember)
        {
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
