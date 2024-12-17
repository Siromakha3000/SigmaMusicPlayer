using System.Collections.Generic;

namespace SigmaMusicPlayer.Models;

public class PlaylistModel
{
    public string Title { get; set; }
    public List<SongModel> Songs { get; set; }
    public uint CurrentSongIndex { get; set; }
    public uint SongCount => (uint)Songs.Count;
    
    public PlaylistModel(string title, List<SongModel> songs, uint currentSongIndex)
    {
        Title = title;
        Songs = songs;
        CurrentSongIndex = 0;
    }
}