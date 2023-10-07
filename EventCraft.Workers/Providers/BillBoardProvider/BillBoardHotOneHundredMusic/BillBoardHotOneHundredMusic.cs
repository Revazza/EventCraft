using EventCraft.Workers.Providers.BillBoardProvider.BillBoardHotOneHundredMusic.Models;
using EventCraft.Workers.Services;

namespace EventCraft.Workers.Providers.BillBoardProvider.BillBoardHotOneHundredMusic;

public class BillBoardHotOneHundredMusic : BillBoardBase
{
    public override async Task<string> GetAsync()
    {
        var request = CreateRequest("hot-100", DateTime.Now, 100);
        return await new Fetcher(request).FetchAsync(); 
    }

}