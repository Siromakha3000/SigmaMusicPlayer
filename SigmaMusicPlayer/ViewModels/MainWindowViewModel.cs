using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using SigmaMusicPlayer.Models;

namespace SigmaMusicPlayer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private Player _player;
    public MainWindowViewModel()
    {
        // Player.Instance();
    }
    
    [RelayCommand]
    public async Task PlayFromFile(Window mainWindow)
    {
        Console.WriteLine("Command triggered");
        if (mainWindow == null)
        {
            Console.WriteLine("Main window is null");
            return;
        }
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
        Console.WriteLine("Selected file: " + uri);
        if(_player == null)
        {
            _player = new Player();
        }
        Console.WriteLine("Loading song model into pipeline");
        _player.LoadIntoPipeline(uri);
        Console.WriteLine("Playing " + uri);
        // _player.Play();
        // return Task.CompletedTask;
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
        _player.Play();
    }
    
}