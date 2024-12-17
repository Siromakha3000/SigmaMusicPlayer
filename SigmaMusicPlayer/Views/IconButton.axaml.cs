using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Material.Icons;
using SigmaMusicPlayer.ViewModels;

namespace SigmaMusicPlayer.Views;

public partial class IconButton : UserControl
{
    public IconButton()
    {
        InitializeComponent();
    }

    // StyledProperty for Icon
    public static readonly StyledProperty<MaterialIconKind?> KindProperty =
        AvaloniaProperty.Register<IconButton, MaterialIconKind?>(nameof(Kind));

    public MaterialIconKind? Kind
    {
        get => GetValue(KindProperty);
        set => SetValue(KindProperty, value);
    }

    // StyledProperty for Text
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<IconButton, string?>(nameof(Text));

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // StyledProperty for Command
    public static readonly StyledProperty<ICommand?> CommandProperty =
        AvaloniaProperty.Register<IconButton, ICommand?>(nameof(Command));

    public ICommand? Command
    {
        get => GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    // StyledProperty for CommandParameter
    public static readonly StyledProperty<object?> CommandParameterProperty =
        AvaloniaProperty.Register<IconButton, object?>(nameof(CommandParameter));

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
}