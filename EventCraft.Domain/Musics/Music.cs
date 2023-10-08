namespace EventCraft.Domain.Musics;

public record MusicId(Guid Value)
{
    public static MusicId Create()
    {
        return new MusicId(Guid.NewGuid());
    }
}

public class Music
{
    public MusicId MusicId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Artist { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int CurrentRank { get; set; }
    public int LastWeekRank { get; set; }
    public int PeekRank { get; set; }

}

/*
  {
      "rank": "7",
      "title": "Without Me",
      "artist": "Halsey",
      "last week": "6",
      "peak position": "1",
      "weeks on chart": "30",
      "detail": "down"
    },

*/
