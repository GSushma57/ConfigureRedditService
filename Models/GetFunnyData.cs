using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace ConfigureRedditService.Models
{
    public class GetFunnyData
    {
        public string After { get; set; }
        public int Count { get; set; }

        public string Before { get; set; }


    }
}
