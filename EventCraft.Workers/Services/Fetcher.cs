using EventCraft.Workers.Interfaces;

namespace EventCraft.Workers.Services;

public class Fetcher : IFetcher
{
    private readonly HttpRequestMessage _request;
    public Fetcher(HttpRequestMessage request)
    {
        _request = request;
    }

    public async Task<string> FetchAsync()
    {
        var client = new HttpClient();
        var resposne = await client.SendAsync(_request);
        if (!resposne.IsSuccessStatusCode)
        {
            return string.Empty;
        }

        return await resposne.Content.ReadAsStringAsync();
    }
}