using System.Threading.Tasks;

namespace ConfigureRedditService.Services
{
    public interface IOAuthClientService
    {
        Task<string> GetTokenAsync();
        string Code { set; }

    }
}
