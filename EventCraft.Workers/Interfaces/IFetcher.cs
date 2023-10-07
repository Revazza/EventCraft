namespace EventCraft.Workers.Interfaces;

public interface IFetcher
{
    public Task<string> FetchAsync();
}