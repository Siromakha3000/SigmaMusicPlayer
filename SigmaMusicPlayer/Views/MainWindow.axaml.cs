using System;
using Avalonia;
using Avalonia.Controls;

namespace SigmaMusicPlayer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        
        // Additional setup for overlay behavior
        this.Opacity = 0.9; // Slight transparency
    }
}