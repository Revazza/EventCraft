namespace EventCraft.Workers.Providers.BillBoardProvider;

public abstract class BillBoardBase
{
    // should be moved outside
    private const string API_KEY = "6658b977d4mshb4afd5e8ecc338fp1ad7ebjsnaf7dbb8dce56";
    private const string HOST = "billboard-api2.p.rapidapi.com";

    protected static HttpRequestMessage CreateRequest(string category, DateTime date, int rangeTo)
    {
        //https://billboard-api2.p.rapidapi.com/hot-100?date=2019-05-11&range=1-10
        return new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://{HOST}/{category}?date={date.AddDays(-8):yyyy-MM-dd}&range=1-{rangeTo}"),
            Headers =
            {
                { "X-RapidAPI-Key", API_KEY },
                { "X-RapidAPI-Host", HOST },
            },
        };
    }

    public abstract Task<string> GetAsync();

}