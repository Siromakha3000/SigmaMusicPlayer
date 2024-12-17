using System;

namespace SigmaMusicPlayer.Models;

public class SongModel
{
    public string Uri { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string AlbumArtPath { get; set; }
    public TimeSpan Duration { get; set; }
}