using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SigmaMusicPlayer.Models;
using Gst;
using TagLib;
public class Player
{
    private Pipeline _pipeline;
    public bool IsPipelineNull => _pipeline == null;
    public bool IsPlaying => _pipeline.CurrentState == State.Playing;
    public bool IsPaused => _pipeline.CurrentState == State.Paused;
    
    public Player()
    {
        Gst.Application.Init();
    }
    
    public SongModel LoadSongModel(string uri)
    {
        File file = File.Create(uri);
        TagLib.Tag tag = file.GetTag(TagTypes.Id3v2);
        TimeSpan duration = TimeSpan.FromSeconds(file.Properties.Duration.TotalSeconds);
        string tagtitle = tag.Title;
        string tagartist = string.IsNullOrEmpty(tag.JoinedPerformersSort) ? tag.FirstPerformer : tag.JoinedPerformersSort;
        string title = string.IsNullOrEmpty(tagtitle) ? System.IO.Path.GetFileNameWithoutExtension(uri) : tagtitle;
        string artist = string.IsNullOrEmpty(tagartist) ? "Unknown artist" : tagartist;
        Console.WriteLine($"Title: {tag.Title}, Artist: {tag.JoinedPerformersSort}, Duration: {duration}");
        return new SongModel
        {
            Uri = uri,
            Title = title,
            Artist = artist,
            AlbumArtPath = null,
            Duration = duration
        };
    }
    
    public void LoadIntoPipeline(String uri)
    {
        // var pipeline = (Pipeline)Parse.Launch($"filesrc location={uri} ! decodebin ! audioconvert ! audioresample ! alsasink");
        _pipeline = (Pipeline)Parse.Launch($"filesrc location={uri} ! decodebin ! audioconvert ! audioresample");
        if (_pipeline == null)
        {
            Console.WriteLine("Failed to create pipeline");
            return;
        }
        Console.WriteLine("Pipeline created");
        Play();
    }
    
    public void Play() => _pipeline.SetState(State.Playing);
    public void Pause() => _pipeline.SetState(State.Paused);
    public void PlayPause()
    {
        if (IsPlaying)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }
    public void Stop() => _pipeline.SetState(State.Null);
    public void Seek(TimeSpan position) => _pipeline.Seek(1.0, Format.Time, SeekFlags.Flush | SeekFlags.Accurate, SeekType.Set, position.Ticks, SeekType.None, -1);
    public void Dispose() => _pipeline.Dispose();
    
    ~Player()
    {
        Dispose();
    }
}