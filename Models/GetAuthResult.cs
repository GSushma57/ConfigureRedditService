namespace ConfigureRedditService.Models
{
    public class GetAuthResult
    {
        public required string AccessToken { get; set; }

        public DateTime TokenExpiry { get; set; }

        public bool IsTokenExpiring
        {
            get
            {
                return (DateTime.UtcNow > TokenExpiry);
            }
        }
        public long expires_in { 
        set
            {
                TokenExpiry = DateTime.UtcNow.AddSeconds(value);
            } 
        }

    }
}
