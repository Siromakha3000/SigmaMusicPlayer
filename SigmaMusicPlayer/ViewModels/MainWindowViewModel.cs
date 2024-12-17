using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using SigmaMusicPlayer.Models;

namespace SigmaMusicPlayer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private Player _player;
    
    // ui properties
    // private MaterialIconKind _playButtonIcon = MaterialIconKind.Play;
    // public MaterialIconKind PlayButtonIcon
    // {
    //     get => _playButtonIcon;
    //     set => SetProperty(ref _playButtonIcon, value);
    // }
    
    [ObservableProperty] private bool _isPlaylistEmpty;

    partial void OnPlaylistChanged(List<SongModel> playlist)
    {
        IsPlaylistEmpty = _playlist.Count == 0;
    }
    
    [ObservableProperty]
    private bool _isPlaying;
    
    // playlist properties
    private PlaylistModel playlistModel;
    
    [ObservableProperty]
    private List<SongModel> _playlist;

    [ObservableProperty]
    private SongModel _selectedSong;

    partial void OnSelectedSongChanged(SongModel song)
    {
        if (song == null)
        {
            Console.WriteLine("Selected song is null");
            return;
        }
        Console.WriteLine($"Selected song: {song.Title}");
        _player.LoadIntoPipeline(song.Uri);
    }
    
    public MainWindowViewModel()
    {
        _player = new Player();
        _isPlaylistEmpty = true;
    }
    
    [RelayCommand]
    public async Task PlayFromFile(Window mainWindow)
    {
        // open file dialogue
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filters.Add(new FileDialogFilter { Name = "Audio Files", Extensions = { "mp3", "wav", "ogg" } });
        openFileDialog.AllowMultiple = false;
        openFileDialog.Title = "Select an audio file";
        openFileDialog.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        var result = await openFileDialog.ShowAsync(mainWindow);
        if (result == null || result.Length == 0)
        {
            Console.WriteLine("No file selected");
            return;
        }
        string uri = result![0];
        var song = _player.LoadSongModel(uri);
        PlaylistFromSong(song);
        // load and play the selected file
        // _player.LoadIntoPipeline(uri);
    }
    
    [RelayCommand]
    public void AddPlaylistCommand()
    {
        Console.WriteLine("New playlist command triggered");
    }
    
    [RelayCommand]
    public void PlayPauseCommand()
    {
        Console.WriteLine("Play/Pause command triggered");
        if (_player.IsPipelineNull)
        {
            Console.WriteLine("No pipeline loaded");
            return;
        }
        _player.PlayPause();
        IsPlaying = _player.IsPlaying;
        // PlayButtonIcon = _player.IsPlaying ? MaterialIconKind.Pause : MaterialIconKind.Play;
    }
    
    public void PlaylistFromSong(SongModel song)
    {
        playlistModel = new PlaylistModel("Temporary Playlist", [song], 0);
        Playlist = playlistModel.Songs;
        SelectedSong = Playlist.First();
    }
}