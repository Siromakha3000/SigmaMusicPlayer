using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SigmaMusicPlayer.Models;

namespace SigmaMusicPlayer.ViewModels;

public partial class PlaylistItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private PlaylistItemModel _playlistItem;
    
    [ObservableProperty]
    private bool _isSelected;

    [RelayCommand]
    public void ToggleSelection()
    {
        IsSelected = !IsSelected;
    }
}