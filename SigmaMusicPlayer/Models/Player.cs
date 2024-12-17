using System;

namespace SigmaMusicPlayer.Models;
using Gst;
using TagLib;
public class Player
{
    private readonly Pipeline _pipeline;
    
    public Player()
    {
        Gst.Application.Init();


        // try
        // {
        // Gst.Application.Init();
        // Ensure plugins are loaded
        // Gst.Application.InitCheck();
        //
        // Environment.SetEnvironmentVariable("GST_DEBUG", "3");
        //     Console.WriteLine($"GStreamer Version: {Gst.Version.Description}");
        //
        //     _pipeline = new Pipeline("audio-player");
        // }
        // try
        // {
        //     // Explicit full initialization
        //     Gst.Application.Init();
        //
        //     Console.WriteLine($"GStreamer Version: {Gst.Version.Description}");
        //
        //     // Try creating a simple element first
        //     var element = ElementFactory.Make("fakesrc", "test-source");
        //     
        //     // Then try creating pipeline
        //     var pipeline = new Pipeline("test-pipeline");
        //     
        //     // _pipeline = new Pipeline("playbin");
        //
        //     Console.WriteLine("Successfully initialized GStreamer!");
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine($"Pipeline Creation Error: {e.Message}");
        //     Console.WriteLine($"Inner Exception: {e.InnerException?.Message}");
        //     throw;
        // }
    }
    
    public SongModel LoadSongModel(string uri)
    {
        File file = File.Create(uri);
        TagLib.Tag tag = file.GetTag(TagTypes.Id3v2);
        TimeSpan duration = TimeSpan.FromSeconds(file.Properties.Duration.TotalSeconds);
        return new SongModel
        {
            Uri = uri,
            Title = tag.Title,
            Artist = tag.FirstPerformer,
            AlbumArtPath = null,
            Duration = duration
        };
    }
    public void LoadIntoPipeline(SongModel song)
    {
        // var source = ElementFactory.Make("filesrc", "file-source");
        // var decoder = ElementFactory.Make("decodebin", "decoder");
        // var audioconvert = ElementFactory.Make("audioconvert", "audioconvert");
        // var audioresample = ElementFactory.Make("audioresample", "audioresample");
        // var autoaudiosink = ElementFactory.Make("autoaudiosink", "autoaudiosink");
        // _pipeline.Add(source, decoder, audioconvert, audioresample, autoaudiosink);
        // Element.Link(source, decoder);
        // Element.Link(decoder, audioconvert);
        // Element.Link(audioconvert, audioresample);
        // Element.Link(audioresample, autoaudiosink);
        // source["location"] = song.Uri;
    }
    
    public void LoadIntoPipeline(String uri)
    {
        var pipeline = (Pipeline)Parse.Launch($"filesrc location={uri} ! decodebin ! audioconvert ! audioresample ! alsasink");
        if (pipeline == null)
        {
            Console.WriteLine("Failed to create pipeline");
        }
        pipeline.SetState(State.Playing);
    }
    
    public void Play() => _pipeline.SetState(State.Playing);
    public void Pause() => _pipeline.SetState(State.Paused);
    public void Stop() => _pipeline.SetState(State.Null);
}