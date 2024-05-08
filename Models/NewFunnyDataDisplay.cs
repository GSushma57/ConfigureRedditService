namespace ConfigureRedditService.Models
{
    public class NewFunnyDataDisplay
    {
        public string Subreddit { get; set; }
        public string Title { get; set; }

        public string? Selftext { get; set; }

        public string Author_fullname { get; set; }

        public int? Total_awards_received { get; set; }
    }
}
