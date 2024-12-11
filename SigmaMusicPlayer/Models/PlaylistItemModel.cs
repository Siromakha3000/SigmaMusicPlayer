using System;

namespace SigmaMusicPlayer.Models;

public class PlaylistItemModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string AlbumArtPath { get; set; }
    public TimeSpan Duration { get; set; }
}