using ConfigureRedditService.Models;

namespace ConfigureRedditService.Services
{
    public interface IFunnyDataService
    {
        Task<IEnumerable<GetFunnyData>> GetNewFunnyDataAsync();
    }
}
