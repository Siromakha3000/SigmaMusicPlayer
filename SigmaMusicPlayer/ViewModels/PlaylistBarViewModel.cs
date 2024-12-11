using CommunityToolkit.Mvvm.ComponentModel;
using SigmaMusicPlayer.Models;

namespace SigmaMusicPlayer.ViewModels;

public class PlaylistBarViewModel : ViewModelBase
{
    public PlaylistItemModel CurrentSong { get; set; }
    public PlaylistItemModel NextSong { get; set; }
    public PlaylistItemModel PreviousSong { get; set; }
}